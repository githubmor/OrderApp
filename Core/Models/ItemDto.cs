using System;
using System.Collections.Generic;
namespace Core.Models
{
    public class ItemDto
    {
        public bool IsSelected { get; set; }
        public KalaDto ItemKala { get; set; }
        public int Tedad { get; set; }
        public int Karton { get; set; }
        public int PalletCount { get; set; }
        public MaghsadDto ItemMaghsad { get; set; }
        public int Vazn { get; set; }
        public RanandeDto ItemRanande { get; set; }
        public Vaziat ItemKind { get; set; }
        public string Des { get; set; }
        public int TahvilFrosh { get; set; }
    }

    public class dbItemDto
    {
    }

    public enum Vaziat
    {
        
    }
}