
using System;

namespace TP.HtmlGenerate.table {
    public class TableGenerate {
        /// <summary>
        /// 整体
        /// </summary>
        private String htmlBody;
        /// <summary>
        /// css
        /// </summary>
        private String cssStyle;
        /// <summary>
        /// table主体部分
        /// </summary>
        private String tableMain;

        private void setStyle(String style = "") { 
             if(style == "") { 
                cssStyle = @"<style>
                                table {
	                                text-align: center;
	                                margin: 0 auto;
	                                font-size: 13px;
                                }
                                table tr td {
	                                border: 1px solid #cccccc;
	                                padding: 5px;
	                                border-collapse: collapse;
                                }
                                table tr th {
	                                padding: 10px;
	                                font-size: 14px
                                }
                                </style>";
             }   
        }

        public void setTableTitle() {
            
        }
        
    }
}
