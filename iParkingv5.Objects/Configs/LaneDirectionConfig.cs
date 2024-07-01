using System;
using System.Collections.Generic;
using System.Text;

namespace iParkingv5.Objects.Configs
{
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
                IsDisplayLastEvent = true
            };
        }
    }
}
