using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XAFSkelbimaiPrograma.Parser.Helpers
{
    public class UserParseInfoDto
    {
        private object m_userId;
        private bool m_allowParse;
        private bool m_email;
        private bool m_photo;

        public object UserId 
        { 
            get { return m_userId; }
            set { m_userId = value; }
        }

        public bool AllowParse
        {
            get { return m_allowParse; }
            set { m_allowParse = value; }
        }

        public bool Email
        {
            get { return m_email; }
            set { m_email = value; }
        }

        public bool Photo
        {
            get { return m_photo; }
            set { m_photo = value; }
        }
    }
}
