
# ASP.NET Core WebApi for Article listing

This .NET Core API is an exercise for showcasing the ability in developing a REST API and integrating 3rd
party services. The 3rd party involve is https://jsonmock.hackerrank.com/api/articles
All of the methods used are in GET.

Hope this helps.

See the examples here: 

## Versions

``` https://localhost:44313/swagger ```

![image](https://user-images.githubusercontent.com/30335870/184791530-edb8e063-31d9-469f-a39f-9320eeef9a1d.png)

### Prerequisite:

- .NET Core 3.1
- Visual Studio 2019 or greater versions

## Setting Up

To setup this project, you need to clone the git repo

```sh
$ git clone https://github.com/appsforralph/ArticleTest.git
$ cd ArticleTest
```

followed by

```sh
$ dotnet restore
```



### Running the Project
Alter first the aritcleApiURL needed. It is located in the appsetting.json
- aritcleApiURL : "https://jsonmock.hackerrank.com"



#### Run via command line
```sh
$ dotnet build --configuration Release
$ dotnet run --project ./ArticleTest/ArticleTest.csproj --urls=https://localhost:44313/
```


#### Run via Visual Studio UI
On running it via Visual Studio UI, simply click the IIS run button
![image](https://user-images.githubusercontent.com/30335870/184792381-d7ebf992-b2e7-45c1-b2e7-fe28cae19f65.png)



### Get the topArticles
![image](https://user-images.githubusercontent.com/30335870/184791439-f151a571-ca39-425b-8a2a-40445adc3f3b.png)


