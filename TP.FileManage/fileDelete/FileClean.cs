using System;
using System.IO;
using System.Linq;

namespace TP.FileManage.fileDelete {
    /// <summary>
    /// 根据条件删除文件
    /// </summary>
    public class FileClean {
        /// <summary>
        /// 删除文件夹strDir中nDays天以前的文件
        /// </summary>
        /// <param name="filePath"> 传入指定文件路径 </param>
        /// <param name="days"> 文件创建或更新  存在天数 > days 的文件会被删除 </param>
        public String deleteOldFiles(String filePath, int days) {
            try {
                if (!Directory.Exists(filePath) || days < 1) {return "文件夹地址不存在或天数小于0";};

                var now = DateTime.Now;
                foreach (var f in Directory.GetFileSystemEntries(filePath).Where(f => File.Exists(f))) {
                    var t = File.GetCreationTime(f);

                    var elapsedTicks = now.Ticks - t.Ticks;
                    var elapsedSpan = new TimeSpan(elapsedTicks);

                    if (elapsedSpan.TotalDays > days) File.Delete(f);
                }
                return "OK";
            } catch (Exception ex) {
                return ex.ToString();
            }
        }
    }
}
