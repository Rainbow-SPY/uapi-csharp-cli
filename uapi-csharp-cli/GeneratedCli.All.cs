using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class GeneratedCliAll
    {
        public static void AddCommands(RootCommand root, Option<string> outOption, Option<bool> appendOption,
            Option<string> authenticationOption)
        {
            Cli_API_HealthPlatformStatus.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_API_Usage.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Clipzy_Clipzy.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_EpicGames_GetFreeGames.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Github_GetRepoData.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Hotboard_NeteaseMusic.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Hotboard_bilibili.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_IConvert.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Image_Image_BingDaily.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Image_Image_Compress.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Image_Image_Convert.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Image_Image_DailyNews.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Image_Image_DecodeForOtherDevices.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Image_Image_Motou.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Image_Image_OCR.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Image_Image_ToBase64.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Image_Image_WhyDontSayAnything.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Image_Image_nsfw.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Image_image_Gravator.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Image_image_QRCode.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Minecraft_SearchMod.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Minecraft_Version.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Misc_Misc_ConvertTimestamp.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Misc_Misc_DetectTrackingCarrier.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Misc_Misc_GetHolidayCalendar.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Misc_Misc_GetLunarTime.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Misc_Misc_GetPhoneInfo.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Misc_Misc_GetProgrammerHistoryToday.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Misc_Misc_GetRandomNumberList.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Misc_Misc_GetTrackingCarriers.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Misc_Misc_GetTrackingInfo.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Misc_Misc_GetWorldTime.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Misc_Misc_PostDateDiff.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Network_Network_DNS.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Network_Network_GetMyIP.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Network_Network_ICP.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Network_Network_IPInfo.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Network_Network_Ping.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Network_Network_PingMyIP.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Network_Network_PortScan.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Network_Network_UrlStatus.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Network_Network_WeixinDomain.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Network_Network_WhoIs.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_QQ_GetGroupData.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_QQ_GetUserData.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Search_GetConfig.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Search.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Steam_Steam_GetUserData.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Steam_Steam_Servers.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Text_Text_AES_Advanced.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Text_Text_AES.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Text_Text_AnalyzeText.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Text_Text_AnswerBook.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Text_Text_Base64.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Text_Text_CheckSemsitiveWords_Get.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Text_Text_CheckSensitiveWords_Analyze.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Text_Text_CheckSensitiveWords_Fast.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Text_Text_DailyWord.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Text_Text_MD5_Verify.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Text_Text_MD5.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Text_Text_Saying.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Text_Text_Translate_AI.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Text_Text_Translate.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Text_Text_WordMetaData.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Text_text_Convert.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Text_text_Markdown.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_Weather_GetWeather.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_WebParse_WebParse_ExtractImages.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_WebParse_WebParse_GetMetaData.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_WebParse_WebParse_ToMarkdown.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_bilibili_bilibili_GetArchives.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_bilibili_bilibili_GetLiveroomStatus.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_bilibili_bilibili_GetRepliesList.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_bilibili_bilibili_GetUserData.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_bilibili_bilibili_GetVideoData.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_minecraft_GetHistoryName.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_minecraft_GetServerStatus.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_minecraft_GetUserData.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_random_Image.AddCommands(root, outOption, appendOption, authenticationOption);
            Cli_random_Text.AddCommands(root, outOption, appendOption, authenticationOption);
        }
    }
}