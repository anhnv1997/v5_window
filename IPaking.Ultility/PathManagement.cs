namespace IPaking.Ultility
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
        public static string oemConfigPath => baseBath + "/configs/app/oem.txt";
        public static string tokenPath => baseBath + "/configs/app/refreshToken.txt";
        public static string thirtPartyConfigPath => baseBath + "/configs/app/thirtParty.txt";
        public static string appDisplayConfigPath(string laneID) => baseBath + $"/configs/app/{laneID}/displayConfig.txt";
        public static string appLaneDirectionConfigPath(string laneId) => baseBath + $"/configs/app/{laneId}/displayDirection.txt";
        public static string databaseConfigPath => baseBath + "/configs/app/database.xml";
        public static string appActiveLaneConfigPath() => baseBath + $"/configs/app/activeLane.txt";
        public static string appPrintTemplateConfigPath(string printTemplateName) => baseBath + $"/configs/app/print/{printTemplateName}.html";
        public static string appPrintTemplateWarehousePath(string printTemplateName) => baseBath + $"/configs/app/print/{printTemplateName}Warehouse.html";
        public static string appPrintScaleTemplateConfigPath(string printTemplateName) => baseBath + $"/configs/app/print/{printTemplateName}Scale.html";
        public static string appPrintScaleInvoiceOfflineTemplateConfigPath(string printTemplateName) => baseBath + $"/configs/app/print/{printTemplateName}ScaleInvoiceOffline.html";
        public static string appPrintPhieuThu(string printTemplateName) => baseBath + $"/configs/app/print/{printTemplateName}_phieuthu.html";
        #endregion END APP CONFIG PATH

        #region LANE CONFIG PATH
        public static string laneShortcutConfigPath(string laneId) => baseBath + $"/configs/{laneId}/lane/baseShortcut.txt";
        public static string laneControllerShortcutConfigPath(string laneId) => baseBath + $"/configs/{laneId}/lane/controllerShortcut.txt";
        public static string laneLedConfigPath(string laneId, string ledId) => baseBath + $"/configs/{laneId}/led/{ledId}.txt";
        public static string laneCameraConfigPath(string laneId, string cameraId) => baseBath + $"/configs/{laneId}/camera/{cameraId}.txt";
        public static string sharedPreferencesPath() => baseBath + "/configs/app/sharedPreferences.txt";
        public static string laneControllerReaderConfigPath(string laneId, string controllerId, int readerIndex) => baseBath + $"/configs/{laneId}/{controllerId}_{readerIndex}/reader_config.txt";
        #endregion END LANE CONFIG PATH

        #region V3 CONFIG
        public static string ledDisplayConfigTypePath => baseBath + $"/configs/led/ledDisplayConfigTypePath.txt";
        public static string ledListPath => baseBath + $"/configs/led/data.txt";
        public static string colorConfigPath => baseBath + $"/configs/led/colorConfig.txt";

        #endregion

        #region Haus
        public static string hausQRPath() => baseBath + $"/configs/app/print/haus_qr.html";
        #endregion

    }
}