// <copyright file="RestXrayAPI.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MCS.Test.Automation.Tests.NUnit
{
    using System;
    using System.IO;
    using MCS.Test.Automation.Common;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using NLog;
    using RelevantCodes.ExtentReports;
    using RestSharp;

    /// <summary>
    /// The base class for all RestAPI Calls and executions.
    /// </summary>
    public class RestXrayAPI : ProjectTestBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public static string GetJsonString(string filename)
        {
            string inputjson = File.ReadAllText(filename);
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(inputjson, Formatting.None);
            return jsonData;
        }

        // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times", Justification = "need to remove")]
        public static string RestJson(string filename)
        {
            string strErrorMsg = string.Empty;
            try
            {
                string url = BaseConfiguration.JiraAPIUrl;

                // Send API url to the RestClient
                RestClient restclient = new RestClient();
                restclient.BaseUrl = new Uri(url);

                // Send request to Add Company using POST api
                var request1 = new RestRequest(Method.POST);

                // Adding Headers to the request
                request1.AddHeader("Content-Type", "application/json");
                request1.RequestFormat = DataFormat.Json;

                // request1.AddHeader("authorization", AccessToken);
                request1.AddHeader("cache-control", "no-cache");
                request1.AddHeader("Authorization", BaseConfiguration.JiraAPIAuth);

                // Deserialize the Json request data
                var obj = JsonConvert.DeserializeObject(GetJsonString(filename));
                request1.AddJsonBody(obj);
                request1.AddParameter("application/json", obj, ParameterType.RequestBody);

                // Retrieve the REST response
                IRestResponse response = restclient.Execute(request1);

                // Statucsode of the reponse
                var strStatusCode = response.StatusCode;
                strErrorMsg = response.ErrorMessage;

                // Status of the reponse
                var responseStatus = response.ResponseStatus.ToString();
                Console.WriteLine(responseStatus);

                // var customerDto = JsonConvert.DeserializeObject(response.Content);
                dynamic joResponse = JObject.Parse(response.Content.ToString());
                string keyOftestExecution = joResponse.testExecIssue.key;
                string log = string.Empty;
                foreach (string s in SuiteLevelConfiguration.JsonTestEvidenceFileNameKey)
                {
                    log = log + s + ",";
                }

                Logger.Info("FileName and ID : " + log.TrimEnd(','));
                Logger.Info("JIRA Execution Key : " + keyOftestExecution);
                return strStatusCode.ToString() + keyOftestExecution;
            }
            catch (Exception)
            {
                DriverContext.ExtentStepTest.Log(LogStatus.Fail, " To Post Execution result in JIRA via RestAPI ", strErrorMsg);
                Logger.Error(strErrorMsg);
                throw;
            }
        }

        // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2202:Do not dispose objects multiple times", Justification = "need to remove")]
        public static string RestNUnit()
        {
            string url = BaseConfiguration.JiraNUnitRestUrl;

            // Send API url to the RestClient
            RestClient restclient = new RestClient();
            restclient.BaseUrl = new Uri(url);

            // Send request to Add Company using POST api
            var request1 = new RestRequest(Method.POST);

            // Adding Headers to the request
            request1.AddHeader("Content-Type", "multipart/form-data");

            // request1.RequestFormat = DataFormat.Json;
            // request1.AddHeader("authorization", AccessToken);
            request1.AddHeader("cache-control", "no-cache");
            request1.AddHeader("Authorization", "Basic anNpbmdoOlJlZ3Jlc3Npb25AMTIzNDU=");

            // Deserialize the Json request data
            // var obj = JsonConvert.DeserializeObject(GetJsonString(filename));
            // request1.AddJsonBody(obj);
            request1.AddFile("file", File.ReadAllBytes(BaseConfiguration.JiraNUnitRestFileLocation), Path.GetFileName(BaseConfiguration.JiraNUnitRestFileLocation), "multipart/form-data");

            // request1.AddParameter("file", ParameterType.RequestBody);
            // Retrieve the REST response
            IRestResponse response = restclient.Execute(request1);
            dynamic joResponse = JObject.Parse(response.Content.ToString());
            string keyOftestExecution = joResponse.testExecIssue.key;
            string log = string.Empty;
            foreach (string s in SuiteLevelConfiguration.JsonTestEvidenceFileNameKey)
            {
                log = log + s + ",";
            }

            Logger.Info("FileName and ID : " + log.TrimEnd(','));
            Logger.Info("JIRA Execution Key : " + keyOftestExecution);
            var strStatusCode = response.StatusCode;

            // Status of the reponse
            var responseStatus = response.ResponseStatus.ToString();
            Console.WriteLine(responseStatus);
            return strStatusCode.ToString();
        }
    }
}
