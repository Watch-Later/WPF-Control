﻿using System.ComponentModel.DataAnnotations;

namespace H.App.FileManager
{
    public class fm_dd_video_image : fm_dd_image
    {
        [Display(Name = "视频中的位置")]
        public long TimeStamp { get; set; }
    }
}
