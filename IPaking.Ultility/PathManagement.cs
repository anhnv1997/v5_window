﻿namespace IPaking.Ultility
{
    public class PathManagement
    {
        #region APP CONFIG PATH
        public static string baseBath = string.Empty;
        public static string serverConfigPath => baseBath + "/configs/app/server.txt";
        public static string lprConfigPath => baseBath + "/configs/app/lpr.txt";
        public static string einvoiceConfigPath => baseBath + "/configs/app/einvoice.txt";
        public static string appOptionConfigPath => baseBath + "/configs/app/option.txt";
        public static string appServicesConfigPath => baseBath + "/configs/app/services.txt";
        public static string scaleConfigPath => baseBath + "/configs/app/scale.txt";
        public static string thirtPartyConfigPath => baseBath + "/configs/app/thirtParty.txt";
        public static string appDisplayConfigPath(string laneID) => baseBath + $"/configs/app/{laneID}/displayConfig.txt";
        public static string appLaneDirectionConfigPath(string laneId) => baseBath + $"/configs/app/{laneId}/displayDirection.txt";

        public static string databaseConfigPath => baseBath + "/configs/app/database.xml";
        public static string appActiveLaneConfigPath() => baseBath + $"/configs/app/activeLane.txt";
        public static string appPrintTemplateConfigPath(string printTemplateName) => baseBath + $"/configs/app/print/{printTemplateName}.html";
        public static string appPrintScaleTemplateConfigPath(string printTemplateName) => baseBath + $"/configs/app/print/{printTemplateName}Scale.html";
        #endregion END APP CONFIG PATH

        #region LANE CONFIG PATH
        public static string laneShortcutConfigPath(string laneId) => baseBath + $"/configs/{laneId}/lane/baseShortcut.txt";
        public static string laneControllerShortcutConfigPath(string laneId) => baseBath + $"/configs/{laneId}/lane/controllerShortcut.txt";
        public static string laneLedConfigPath(string laneId, string ledId) => baseBath + $"/configs/{laneId}/led/{ledId}.txt";
        public static string laneCameraConfigPath(string laneId, string cameraId) => baseBath + $"/configs/{laneId}/camera/{cameraId}.txt";
        #endregion END LANE CONFIG PATH
    }
}