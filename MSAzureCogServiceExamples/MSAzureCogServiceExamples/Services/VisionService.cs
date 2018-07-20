using Microsoft.ProjectOxford.Vision;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MSAzureCogServiceExamples.Services
{
    public class VisionService
    {
        public static async Task<string> GetImageDescription(Stream stream)
        {
            var visionClient = new VisionServiceClient(CognitiveServicesKeys.VisionKey, "https://westcentralus.api.cognitive.microsoft.com/vision/v1.0");

            var result = await visionClient.DescribeAsync(stream);

            var topMessage = result.Description.Captions.OrderBy(c => c.Confidence).FirstOrDefault();

            var message = string.Empty;

            if (topMessage == null)
                message = "Oh no, I can't find any smart caption for this picture... Sorry!";
            else
                message = $" I think I see, {topMessage.Text}, I am {Math.Round(topMessage.Confidence * 100, 2)}% sure";

            return message;
        }
    }
}
