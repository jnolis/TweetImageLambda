namespace TweetImage

type Config = {
    TweetImageUrl: string
    TweetText: string
    ConsumerKey: string
    ConsumerSecret: string
    AccessToken: string
    AccessTokenSecret: string
}

module Program =
    open System
    open System.IO
    open System.Text
    open Amazon.Lambda.Core
    open Tweetinvi.Core
    open Newtonsoft.Json
    
    let getConfig (filename:string) =
        File.ReadAllText filename
        |> JsonConvert.DeserializeObject<Config>

    let getImage (url:string) =
        let client = new System.Net.Http.HttpClient()
        client.GetByteArrayAsync(url)
        |> Async.AwaitTask
        |> Async.RunSynchronously

    let handler(context:ILambdaContext) =
        let config = getConfig "config.json"

        Tweetinvi.Auth.ApplicationCredentials <- 
            Tweetinvi.Auth.CreateCredentials(
                config.ConsumerKey,
                config.ConsumerSecret,
                config.AccessToken,
                config.AccessTokenSecret)
        
        let image = getImage config.TweetImageUrl
        let text = config.TweetText

        Tweetinvi.Tweet.PublishTweetWithImage(text,image)
        |> ignore