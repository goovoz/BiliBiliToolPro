namespace Ray.BiliBiliTool.Agent.BiliBiliAgent.Dtos.ApiApi.VipBigPoint;

/// <summary>
/// 开始观看剧集任务（/pgc/activity/deliver/material/receive）。
/// 字段集合与 2026-11-13 实测通过的请求完全一致（免签名，cookie 认证）。
/// </summary>
public class StartOgvWatchRequest
{
    public StartOgvWatchRequest(long epId = 328482, long seasonId = 12548)
    {
        ep_id = epId;
        season_id = seasonId;
    }

    public long ep_id { get; set; }

    public long season_id { get; set; }

    public string activity_code { get; set; } = "";

    public string spmid { get; set; } = "united.player-video-detail.0.0";

    public string c_locale { get; } = "zh_CN";
    public string channel { get; } = "bili";
    public string s_locale { get; } = "zh_CN";
    public string from_spmid { get; } = "activity.h5.0.0";
    public string build { get; } = "9190400";
    public string mobi_app { get; } = "android";
    public string platform { get; } = "android";
    public int disable_rcmd { get; } = 0;
}
