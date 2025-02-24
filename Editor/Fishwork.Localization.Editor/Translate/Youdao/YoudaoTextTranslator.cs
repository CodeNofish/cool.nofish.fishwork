// using System;
// using System.Collections.Generic;
// using System.Security.Cryptography;
// using System.Text;
//
// namespace Fishwork.Localization.Editor {
//
//   public class YoudaoTextTranslator {
//     private const string YoudaoUrl = "https://openapi.youdao.com/api";
//     public string AppKey { get; set; }
//     public string AppSecret { get; set; }
//
//     public void Test() {
//       var form = new Dictionary<string, string>();
//     }
//     
//     public class Request {
//       /// <summary>
//       /// 待翻译文本，必须是UTF-8编码
//       /// </summary>
//       public string Q;
//
//       /// <summary>
//       /// 源语言
//       /// </summary>
//       public string From;
//
//       /// <summary>
//       /// 目标语言
//       /// </summary>
//       public string To;
//
//       /// <summary>
//       /// 应用ID
//       /// </summary>
//       public string AppKey;
//
//       /// <summary>
//       /// 随机字符串，可使用UUID进行生产
//       /// </summary>
//       public string Salt;
//
//       /// <summary>
//       /// 签名 sha256(应用ID+input+salt+curtime+应用密钥)
//       /// </summary>
//       public string Sign;
//
//       /// <summary>
//       /// 签名类型 v3
//       /// </summary>
//       public string SignType = "v3";
//
//       /// <summary>
//       /// 当前UTC时间戳(秒) 
//       /// </summary>
//       public string CurTime;
//
//       #region 可选参数
//       /// <summary>
//       /// 翻译结果音频格式，支持mp3
//       /// </summary>
//       public string Ext;
//
//       /// <summary>
//       /// 翻译结果发音选择，0为女声，1为男声。默认为女声
//       /// </summary>
//       public string Voice;
//
//       /// <summary>
//       /// <para>是否严格按照指定from和to进行翻译：true/false</para>
//       /// <para> 如果为false，则会自动中译英，英译中。默认为false </para>
//       /// </summary>
//       public string Strict;
//
//       /// <summary>
//       /// <para>用户上传的术语表</para>
//       /// 用户指定的术语表ID： out_id，支持英中互译，更多语种方向请前往控制台查询
//       /// </summary>
//       public string VocabId;
//
//       /// <summary>
//       /// <para>领域化翻译</para>
//       /// 默认为：general。仅在控制台开通领域化翻译的情况下可传
//       /// </summary>
//       public string Domain;
//
//       /// <summary>
//       /// <para>拒绝领域化翻译降级-当领域化翻译失败时改为通用翻译</para>
//       /// true或false，默认为：false。仅在控制台开通领域化翻译的情况生效。
//       /// </summary>
//       public string RejectFallback;
//       #endregion
//
//       public Request() { }
//
//       public Dictionary<string, string> GetForm() {
//         // 生成随机字符串
//         Salt = DateTime.Now.Millisecond.ToString();
//         // 生成当前UTC时间戳(秒)
//         TimeSpan ts = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));
//         long millis = (long)ts.TotalMilliseconds;
//         CurTime = Convert.ToString(millis / 1000);
//
//         string signStr = AppKey + Truncate(Q) + Salt + CurTime + Appc;
//         Sign = ComputeHash(signStr, new SHA256CryptoServiceProvider());
//         
//         var form = new Dictionary<string, string>();
//         form.Add("from", From);
//         form.Add("to", To);
//         form.Add("signType", SignType);
//         form.Add("q", System.Web.HttpUtility.UrlEncode(Q));
//         form.Add("appKey", AppKey);
//         form.Add("salt", Salt);
//         form.Add("sign", Sign);
//
//         return form;
//       }
//
//       private static string Truncate(string q) {
//         if (q == null) return null;
//         int len = q.Length;
//         return len <= 20 ? q : (q.Substring(0, 10) + len + q.Substring(len - 10, 10));
//       }
//
//       private string ComputeHash(string input, HashAlgorithm hashAlgorithm) {
//         var inputBytes = Encoding.UTF8.GetBytes(input);
//         var hashedBytes = hashAlgorithm.ComputeHash(inputBytes);
//         return BitConverter.ToString(hashedBytes).Replace("-", "");
//       }
//     }
//   }
//
// }
