using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Kartuves.DL
{
    public class KartuvesContextInitializer : CreateDatabaseIfNotExists<KartuvesContext>
    {
        protected override void Seed(KartuvesContext context)
        {
            base.Seed(context);
            const string temaVardai = "VARDAI";
            const string temaMiestai = "LIETUVOS MIESTAI";
            const string temaValstybes = "VALSTYBES";
            const string temaKita = "KITA";

            List<Subject> temos = new List<Subject>
            {
                new Subject
                {
                    Name = temaVardai,
                    Words = new List<Words>
                    {
                        new Words{Text = "Tomas" },
                        new Words{Text = "Romas" },
                        new Words{Text = "Tadas" },
                        new Words{Text = "Rokas" },
                        new Words{Text = "Timofejus" },
                        new Words{Text = "Almantas" },
                        new Words{Text = "Paulius" },
                        new Words{Text = "Bangimantas" },
                        new Words{Text = "Domas" },
                        new Words{Text = "Antanas" },

                    }
                },
                new Subject
                {
                    Name = temaMiestai,
                    Words = new List<Words>
                    {
                        new Words{Text = "Vilnius" },
                        new Words{Text = "Kaunas" },
                        new Words{Text = "Klaipeda" },
                        new Words{Text = "Siauliai" },
                        new Words{Text = "Panevezys" },
                        new Words{Text = "Alytus" },
                        new Words{Text = "Marijampole" },
                        new Words{Text = "Telsiai" },
                        new Words{Text = "Rokiskis" },
                        new Words{Text = "Zarasai" },

                    }
                },
                new Subject
                {
                    Name = temaValstybes,
                    Words = new List<Words>
                    {
                        new Words{Text = "Lietuva" },
                        new Words{Text = "Vokietija" },
                        new Words{Text = "Lenkija" },
                        new Words{Text = "Latvija" },
                        new Words{Text = "Estija" },
                        new Words{Text = "Suomija" },
                        new Words{Text = "Svedija" },
                        new Words{Text = "Norvegija" },
                        new Words{Text = "Airija" },
                        new Words{Text = "Pracuzija" },

                    }
                },
                new Subject
                {
                    Name = temaKita,
                    Words = new List<Words>
                    {
                        new Words{Text = "Dramblys" },
                        new Words{Text = "Barsukas" },
                        new Words{Text = "Sermuonelis" },
                        new Words{Text = "Gandras" },
                        new Words{Text = "Tigras" },
                        new Words{Text = "Pantera" },
                        new Words{Text = "Karve" },
                        new Words{Text = "Meska" },
                        new Words{Text = "Briedis" },
                        new Words{Text = "Skujuotis" },

                    }
                },


            };
            context.Subjects.AddRange(temos);
        }
    }
}
