# Gameye Sdk for .NET

Create eSport and competitive matches for Counter-Strike: Global Offensive, Team Fortress 2, Left 4 Dead 2, Killing Floor 2, Insurgency and Day of Infamy for your platform without fixed monthly costs or any need for your own server infrastructure. Simply implement the Gameye API to kick off online matches when you need them; you will even be able to implement the scores/statistics directly on your website. How cool is that!

## .NET version
The SDK is built targeting netstandard2.0. This means it should be compatible with apps built against .NET core 2.0 .NET framework 4.6.1, Unity 2018.1, Mono 5.4 or newer versions of
thes packages. For more information see [Microsoft's .NET Standard page.](https://docs.microsoft.com/en-us/dotnet/standard/net-standard)

## Installation
You need an API key to use this SDK, to obtain a free Gameye API key, please send us [an email](mailto:support@gameye.com)

Then, install either with the nuget package manager or via the command line with
```
nuget install Gameye.Sdk
```


## Example!
Watch bots kill each other and get acquainted with our sdk and real-time statistics.

First, get an API key!
Then checkout this repo on your computer.

Export your api key as an environment variable, like this
```
export GAMEYE_API_TOKEN=mysupersecretkey
```
And now, run
```
dotnet run --project ./src/Examples/Examples.csproj
```
to see bots kill eachother!


## Contributing
We encourage everyone to help us improve our public packages. If you want to
contribute please submit a [pull request](https://github.com/Gameye/gameye-sdk-dotnet/pulls).

But, never commit something that breaks the build! You may prevent this a
little bit by linking the `test.sh` script as a git `pre-commit` hook!

like this:
```bash
ln test.sh .git/hooks/pre-commit
```

Now, just before every commit, your code will be compiled and tested!


## License
[BSD (Berkeley Software Distribution) License](https://opensource.org/licenses/bsd-license.php). 2017-2019 Gameye B.V.


## Support
Contact: [gameye.com](https://gameye.com) — support@gameye.com