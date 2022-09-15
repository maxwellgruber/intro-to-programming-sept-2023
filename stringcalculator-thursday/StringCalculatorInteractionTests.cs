
using Moq;

namespace StringCalculator;

public class StringCalculatorInteractionTests
{


    [Theory]
    [InlineData("1", "1")]
    [InlineData("1,2,3", "6")]
    public void CalculatorWritesAnswerToTheLogger(string numbers, string expectedLoggedMessage)
    {
        // Give
        var mockedLogger = new Mock<ILogger>();
        var calculator = new StringCalculator(mockedLogger.Object,
            new Mock<IWebService>().Object
            );
        // When
        var answer = calculator.Add(numbers);
        // Then
        // the logger should have "1" written to it. 
        mockedLogger.Verify(logger => logger.Write(expectedLoggedMessage), Times.Once);
    }

    [Fact]
    public void WhenLoggerThrowsExceptionWebServiceIsCalled()
    {
        // Scenario
        // Given
        var stubbedLogger = new Mock<ILogger>();
        stubbedLogger.Setup(s => s.Write(It.IsAny<string>()))
            .Throws(new LoggingFailureException());
        var mockedWebService = new Mock<IWebService>();
        var calculator = new StringCalculator(
            stubbedLogger.Object, // hand grenade!
            mockedWebService.Object // the mock object that will record interactions
            );

        // When
        calculator.Add("99");

        // Then
        // The Webservice is called with a message.
        mockedWebService.Verify(m => m.Notify("Logger Failed, Result Was 99"));

    }

    [Fact]
    public void WebserviceOnlyCalledOnLoggerException()
    {
        // I need to ask the webservice for it's calls at the end of this test
        // so I will use this like a "mock" object
        var mockedWebService = new Mock<IWebService>();
        var calculator = new StringCalculator(
            new Mock<ILogger>().Object, // Dummy, no exception is thrown
            mockedWebService.Object // the mock object that will record interactions
            );

        // When
        calculator.Add("99"); // Make it do it's thing

        // Make sure the web service is NOT called if there are no exceptions from the
        // logger.
        mockedWebService.Verify(m => m.Notify(It.IsAny<String>()), Times.Never);
    }
}
