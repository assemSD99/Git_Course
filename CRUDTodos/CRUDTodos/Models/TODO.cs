using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace CRUDTodos.Models
{
    public enum State
    {
        TODO,
        DOING,
        DONE

    }
    public class TODO
    {
        [Required]
        public int Id { get; set; }
        public string Libelle { get; set; }
        public string Description { get; set; }
        public State State { get; set; }
        public DateTime DateLimite { get; set; }
    }
}
