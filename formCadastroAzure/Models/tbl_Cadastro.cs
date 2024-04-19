namespace formCadastroAzure
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Cadastro
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }

        [StringLength(50)]
        public string Celular { get; set; }

        [StringLength(50)]
        public string Pais { get; set; }

        [StringLength(50)]
        public string Estado { get; set; }

        [StringLength(50)]
        public string Cidade { get; set; }
    }
}
