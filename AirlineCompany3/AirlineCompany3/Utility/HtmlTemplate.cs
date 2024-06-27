using System;
using System.IO;

namespace AirlineCompany3.Utility
{
    public class HtmlTemplate
    {
        private string _baseHtml;
        private string _htmlBuild;

        public HtmlTemplate(string filePath)
        {
            try
            {
                this._baseHtml = File.ReadAllText(filePath);
                this._htmlBuild = this._baseHtml;
            }
            catch (IOException e)
            {
                Console.WriteLine($"Error reading HTML template file: {e.Message}");
                this._baseHtml = "";
                this._htmlBuild = "";
            }
        }

        public void SetBaseValue(string variable, string value)
        {
            string target = $"{{{variable}}}";
            if (!this._baseHtml.Contains(target))
            {
                return;
            }

            this._baseHtml = this._baseHtml.Replace(target, value);
            SetValue(variable, value);
        }

        public void SetValue(string variable, string value)
        {
            string target = $"{{{variable}}}";
            if (!this._htmlBuild.Contains(target))
            {
                return;
            }

            this._htmlBuild = this._htmlBuild.Replace(target, value);
        }

        public void Reset()
        {
            this._htmlBuild = this._baseHtml;
        }

        public string GetHtml()
        {
            return this._htmlBuild;
        }
    }
}
