# Tweet image lambda

This code is to tweet an image and text from an AWS lambda. I used it to hook up my [AWS IoT button to a twitter account](https://medium.com/@skyetetra/using-f-to-power-an-aws-iot-button-56bea2d36b9).

## Installation instructions:

1. Download and install [.NET Core](https://www.microsoft.com/net/download/core).
2. Create a twitter account, create an [app for the account](https://apps.twitter.com), and get the 4 credentials keys of the app.
2. Create a `config.json` file in the project folder with the required attributes (see `example_config.json` in the project).
3. Open a command line window and move to the project directory, run `dotnet restore` and `dotnet publish` in the directory.
4. zip the resulting publish folder and load it into your Lambda.