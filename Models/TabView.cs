﻿using System.ComponentModel.DataAnnotations;

namespace BlazorTaskManager.Models
{
    public class TabView
    {
        [Key]
        public Guid Id { get; set; }
        public string Label { get; set; }
        public bool ShowCloseIcon { get; set; } = true;
    }
}
