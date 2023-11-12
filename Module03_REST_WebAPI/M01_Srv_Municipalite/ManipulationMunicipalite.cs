using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M01_Srv_Municipalite
{
    public class ManipulationMunicipalite
    {
        private IDepotMunicipalites m_depotMunicipalite;

        public ManipulationMunicipalite(IDepotMunicipalites p_depotMunicipalite)
        {
            m_depotMunicipalite = p_depotMunicipalite;
        }
        public IEnumerable<Municipalite> ListerMuniciapliter()
        {
            return m_depotMunicipalite.ListerMunicipalitesActives();
        }
        public Municipalite ObtenirMunicipalite(int p_codeGeographique)
        {
            return m_depotMunicipalite.ChercherMunicipaliteParCodeGeographique(p_codeGeographique);
        }
        public Municipalite AjouterMunicipalite(Municipalite p_municipalite)
        {
            return m_depotMunicipalite.AjouterMunicipalite(p_municipalite);
        }
        public void SupprimerMunicipalite(int p_codeGeographique)
        {
            Municipalite municipaliteASupprimer = m_depotMunicipalite.ChercherMunicipaliteParCodeGeographique(p_codeGeographique);
            m_depotMunicipalite.DesactiverMunicipalite(municipaliteASupprimer);
        }
        public void MAJMunicipalite(Municipalite p_municipalite)
        {
            m_depotMunicipalite.MAJMunicipalite(p_municipalite);
        }
    }
}
