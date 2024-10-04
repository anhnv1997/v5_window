using iParkingv5.Objects.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Configs
{
    /// <summary>
    /// Thông tin hướng hiển thị trên phần giao diện
    /// </summary>
    public class LaneDirectionConfig
    {
        public enum EmDisplayDirection
        {
            Vertical = 0,
            HorizontalLeftToRight = 1,
            HorizontalRightToLeft = 2,
            VerTicalLeftToRight = 3,
            VerTicalRightToLeft = 4,
        }
        public enum EmCameraDirection
        {
            Vertical = 0,
            Horizontal = 1,
            Table
        }
        public enum EmPicDirection
        {
            Vertical = 0,
            Horizontal = 1,
        }
        public enum EmCameraPicFunction
        {
            Vertical = 0,
            HorizontalLeftToRight = 1,
            HorizontalRightToLeft = 2,
        }
        public enum EmEventDirection
        {
            Vertical = 0,
            HorizontalLeftToRight = 1,
            HorizontalRightToLeft = 2,
        }
        public EmDisplayDirection displayDirection = EmDisplayDirection.HorizontalLeftToRight;
        public EmCameraDirection cameraDirection = EmCameraDirection.Vertical;
        public EmPicDirection picDirection = EmPicDirection.Vertical;
        public EmCameraPicFunction cameraPicDirection = EmCameraPicFunction.Vertical;
        public EmEventDirection eventDirection = EmEventDirection.Vertical;
        public EmCameraResolutionDisplay cameraResolutionDisplay = EmCameraResolutionDisplay.Mode_16_9;

        public bool IsDisplayTitle { get; set; } = true;
        public bool IsDisplayLastEvent { get; set; } = true;


        public static LaneDirectionConfig CreateDefault()
        {
            return new LaneDirectionConfig()
            {
                displayDirection = EmDisplayDirection.HorizontalLeftToRight,
                cameraDirection = EmCameraDirection.Vertical,
                picDirection = EmPicDirection.Vertical,
                cameraPicDirection = EmCameraPicFunction.Vertical,
                eventDirection = EmEventDirection.Vertical,
                IsDisplayTitle = true,
                IsDisplayLastEvent = true,
                cameraResolutionDisplay = EmCameraResolutionDisplay.Mode_16_9
            };
        }
        public bool IsSameConfig(LaneDirectionConfig config)
        {
            return this.displayDirection == config.displayDirection &&
                   this.cameraDirection == config.cameraDirection &&
                   this.picDirection == config.picDirection &&
                   this.cameraPicDirection == config.cameraPicDirection &&
                   this.eventDirection == config.eventDirection &&
                   this.IsDisplayTitle == config.IsDisplayTitle &&
                   this.IsDisplayLastEvent == config.IsDisplayLastEvent &&
                   this.cameraResolutionDisplay == config.cameraResolutionDisplay;
        }
    }
}
