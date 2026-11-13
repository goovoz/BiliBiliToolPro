namespace Ray.BiliBiliTool.Agent.BiliBiliAgent.Dtos.ApiApi.VipBigPoint;

using System.Security.Cryptography;
using System.Text;

/// <summary>
/// 上报完成观看剧集任务（/pgc/activity/deliver/task/complete）。
/// task_sign/sign 为 B 站 app 签名：参数按 ASCII 排序拼接 + appsec 取 md5；
/// task_sign 先算（排除 task_sign 与 sign），sign 再算（含 task_sign）。
/// 字段集合与 2026-11-13 实测通过的请求完全一致，勿增删字段（会破坏签名）。
/// </summary>
public class CompleteOgvWatchRequest
{
    public const string AppKey = "1d8b6e7d45233436";
    public const string AppSec = "560c52ccd288fed045859ed18bffd973";

    public CompleteOgvWatchRequest(long taskId, string token, long timestampMs)
    {
        task_id = taskId;
        this.token = token;
        timestamp = timestampMs;
        var baseParams = ToDictionary();
        task_sign = Sign(baseParams);
        baseParams["task_sign"] = task_sign;
        sign = Sign(baseParams);
    }

    public string appkey { get; } = AppKey;

    public long task_id { get; set; }

    public string token { get; set; }

    public string task_sign { get; set; }

    public long timestamp { get; set; }

    public string sign { get; set; }

    public string c_locale { get; } = "zh_CN";
    public string channel { get; } = "bili";
    public string s_locale { get; } = "zh_CN";
    public string build { get; } = "9190400";
    public string mobi_app { get; } = "android";
    public string platform { get; } = "android";
    public int disable_rcmd { get; } = 0;

    private Dictionary<string, string> ToDictionary()
    {
        return new Dictionary<string, string>
        {
            ["appkey"] = appkey,
            ["build"] = build,
            ["c_locale"] = c_locale,
            ["channel"] = channel,
            ["disable_rcmd"] = disable_rcmd.ToString(),
            ["mobi_app"] = mobi_app,
            ["platform"] = platform,
            ["s_locale"] = s_locale,
            ["task_id"] = task_id.ToString(),
            ["timestamp"] = timestamp.ToString(),
            ["token"] = token,
        };
    }

    private static string Sign(Dictionary<string, string> d)
    {
        var qs = string.Join(
            "&",
            d.OrderBy(x => x.Key, StringComparer.Ordinal)
                .Select(x => x.Key + "=" + x.Value)
        );
        using var md5 = MD5.Create();
        var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(qs + AppSec));
        return Convert.ToHexString(hash).ToLowerInvariant();
    }
}
