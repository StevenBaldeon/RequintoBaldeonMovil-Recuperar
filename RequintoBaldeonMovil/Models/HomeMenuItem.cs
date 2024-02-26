using System;
using System.Collections.Generic;
using System.Text;

namespace RequintoBaldeonMovil.Models
{
    public enum MenuItemType
    {
        Inicio,
        Eventos,
        Patrocinadores,
        RedesSociales,
        Resena

    }
    internal class HomeMenuItem
    {
        public MenuItemType Id { get; set;}
        public string Title { get; set;}
        public string Icon { get; set;}
    }
}
