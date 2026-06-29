using System.CommandLine;

namespace UAPI.CliGenerated
{
    public static class GeneratedCliAll
    {
        public static void AddCommands(RootCommand root, Option<string> outputOption, Option<bool> appendOption,
            Option<string> authenticationOption, Option<string> resultOption, Option<string> selectOption)
        {
            Cli_API_HealthPlatformStatus.AddCommands(root, outputOption, appendOption, authenticationOption,
                resultOption, selectOption);
            Cli_API_Usage.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Clipzy_Clipzy.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_EpicGames_GetFreeGames.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Github_GetRepoData.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Hotboard_NeteaseMusic.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Hotboard_bilibili.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_IConvert.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Image_Image_BingDaily.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Image_Image_Compress.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Image_Image_Convert.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Image_Image_DailyNews.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Image_Image_DecodeForOtherDevices.AddCommands(root, outputOption, appendOption, authenticationOption,
                resultOption, selectOption);
            Cli_Image_Image_Motou.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Image_Image_OCR.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Image_Image_ToBase64.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Image_Image_WhyDontSayAnything.AddCommands(root, outputOption, appendOption, authenticationOption,
                resultOption, selectOption);
            Cli_Image_Image_nsfw.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Image_image_Gravator.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Image_image_QRCode.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Minecraft_SearchMod.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Minecraft_Version.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Misc_Misc_ConvertTimestamp.AddCommands(root, outputOption, appendOption, authenticationOption,
                resultOption, selectOption);
            Cli_Misc_Misc_DetectTrackingCarrier.AddCommands(root, outputOption, appendOption, authenticationOption,
                resultOption, selectOption);
            Cli_Misc_Misc_GetHolidayCalendar.AddCommands(root, outputOption, appendOption, authenticationOption,
                resultOption, selectOption);
            Cli_Misc_Misc_GetLunarTime.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Misc_Misc_GetPhoneInfo.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Misc_Misc_GetProgrammerHistoryToday.AddCommands(root, outputOption, appendOption, authenticationOption,
                resultOption, selectOption);
            Cli_Misc_Misc_GetRandomNumberList.AddCommands(root, outputOption, appendOption, authenticationOption,
                resultOption, selectOption);
            Cli_Misc_Misc_GetTrackingCarriers.AddCommands(root, outputOption, appendOption, authenticationOption,
                resultOption, selectOption);
            Cli_Misc_Misc_GetTrackingInfo.AddCommands(root, outputOption, appendOption, authenticationOption,
                resultOption, selectOption);
            Cli_Misc_Misc_GetWorldTime.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Misc_Misc_PostDateDiff.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Network_Network_DNS.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Network_Network_GetMyIP.AddCommands(root, outputOption, appendOption, authenticationOption,
                resultOption, selectOption);
            Cli_Network_Network_ICP.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Network_Network_IPInfo.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Network_Network_Ping.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Network_Network_PingMyIP.AddCommands(root, outputOption, appendOption, authenticationOption,
                resultOption, selectOption);
            Cli_Network_Network_PortScan.AddCommands(root, outputOption, appendOption, authenticationOption,
                resultOption, selectOption);
            Cli_Network_Network_UrlStatus.AddCommands(root, outputOption, appendOption, authenticationOption,
                resultOption, selectOption);
            Cli_Network_Network_WeixinDomain.AddCommands(root, outputOption, appendOption, authenticationOption,
                resultOption, selectOption);
            Cli_Network_Network_WhoIs.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_QQ_GetGroupData.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_QQ_GetUserData.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Search_GetConfig.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Search.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption, selectOption);
            Cli_Steam_Steam_GetUserData.AddCommands(root, outputOption, appendOption, authenticationOption,
                resultOption, selectOption);
            Cli_Steam_Steam_Servers.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Text_Text_AES_Advanced.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Text_Text_AES.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Text_Text_AnalyzeText.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Text_Text_AnswerBook.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Text_Text_Base64.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Text_Text_CheckSemsitiveWords_Get.AddCommands(root, outputOption, appendOption, authenticationOption,
                resultOption, selectOption);
            Cli_Text_Text_CheckSensitiveWords_Analyze.AddCommands(root, outputOption, appendOption,
                authenticationOption, resultOption, selectOption);
            Cli_Text_Text_CheckSensitiveWords_Fast.AddCommands(root, outputOption, appendOption, authenticationOption,
                resultOption, selectOption);
            Cli_Text_Text_DailyWord.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Text_Text_MD5_Verify.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Text_Text_MD5.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Text_Text_Saying.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Text_Text_Translate_AI.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Text_Text_Translate.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Text_Text_WordMetaData.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Text_text_Convert.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Text_text_Markdown.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_Weather_GetWeather.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_WebParse_WebParse_ExtractImages.AddCommands(root, outputOption, appendOption, authenticationOption,
                resultOption, selectOption);
            Cli_WebParse_WebParse_GetMetaData.AddCommands(root, outputOption, appendOption, authenticationOption,
                resultOption, selectOption);
            Cli_WebParse_WebParse_ToMarkdown.AddCommands(root, outputOption, appendOption, authenticationOption,
                resultOption, selectOption);
            Cli_bilibili_bilibili_GetArchives.AddCommands(root, outputOption, appendOption, authenticationOption,
                resultOption, selectOption);
            Cli_bilibili_bilibili_GetLiveroomStatus.AddCommands(root, outputOption, appendOption, authenticationOption,
                resultOption, selectOption);
            Cli_bilibili_bilibili_GetRepliesList.AddCommands(root, outputOption, appendOption, authenticationOption,
                resultOption, selectOption);
            Cli_bilibili_bilibili_GetUserData.AddCommands(root, outputOption, appendOption, authenticationOption,
                resultOption, selectOption);
            Cli_bilibili_bilibili_GetVideoData.AddCommands(root, outputOption, appendOption, authenticationOption,
                resultOption, selectOption);
            Cli_minecraft_GetHistoryName.AddCommands(root, outputOption, appendOption, authenticationOption,
                resultOption, selectOption);
            Cli_minecraft_GetServerStatus.AddCommands(root, outputOption, appendOption, authenticationOption,
                resultOption, selectOption);
            Cli_minecraft_GetUserData.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_random_Image.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
            Cli_random_Text.AddCommands(root, outputOption, appendOption, authenticationOption, resultOption,
                selectOption);
        }
    }
}