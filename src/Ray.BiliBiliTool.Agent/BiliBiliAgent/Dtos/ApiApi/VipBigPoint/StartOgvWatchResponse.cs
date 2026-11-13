namespace Ray.BiliBiliTool.Agent.BiliBiliAgent.Dtos.ApiApi.VipBigPoint;

public class StartOgvWatchResponse
{
    public string? closeType { get; set; }

    public string? showTime { get; set; }

    public WatchCountDownCfg? watch_count_down_cfg { get; set; }

    public long task_id { get; set; }

    public string? token { get; set; }

    public long EffectiveTaskId => watch_count_down_cfg != null && watch_count_down_cfg.task_id != 0
        ? watch_count_down_cfg.task_id
        : task_id;

    public string? EffectiveToken => watch_count_down_cfg != null && !string.IsNullOrEmpty(watch_count_down_cfg.token)
        ? watch_count_down_cfg.token
        : token;

    public long WatchMilliseconds => watch_count_down_cfg != null && watch_count_down_cfg.milliseconds > 0
        ? watch_count_down_cfg.milliseconds
        : 600_000;
}

public class WatchCountDownCfg
{
    public long task_id { get; set; }

    public string? token { get; set; }

    public long milliseconds { get; set; }
}
