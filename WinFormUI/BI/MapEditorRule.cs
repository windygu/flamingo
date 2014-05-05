using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFormUI.BI
{
    class MapEditorRule
    {
        private String m_ruleCode;


        private String m_ruleText;

        public String RuleCode
        {
            get { return m_ruleCode; }
            set { m_ruleCode = value; }
        }

        public String RuleText
        {
            get { return m_ruleText; }
            set { m_ruleText = value; }
        }
        public MapEditorRule()
        {
        }
        public MapEditorRule(String ruleCode, String ruleText)
        {
            this.RuleCode = ruleCode;
            this.RuleText = ruleText;
        }
    }
}
