﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

namespace BootstrapBlazor.Components;

/// <summary>
/// ContextMenuItem 类
/// </summary>
public class ContextMenuItem : ComponentBase, IDisposable
{
    /// <summary>
    /// 获得/设置 显示文本
    /// </summary>
    [Parameter]
    public string? Text { get; set; }

    /// <summary>
    /// 获得/设置 图标
    /// </summary>
    [Parameter]
    public string? Icon { get; set; }

    /// <summary>
    /// 获得/设置 是否被禁用 默认 false 优先级低于 <see cref="OnDisabledCallback"/>
    /// </summary>
    [Parameter]
    public bool Disabled { get; set; }

    /// <summary>
    /// 获得/设置 是否被禁用回调方法 默认 null 优先级高于 <see cref="Disabled"/>
    /// </summary>
    [Parameter]
    public Func<ContextMenuItem, object?, bool>? OnDisabledCallback { get; set; }

    /// <summary>
    /// 获得/设置 点击回调方法 默认 null
    /// </summary>
    [Parameter]
    public Func<ContextMenuItem, object?, Task>? OnClick { get; set; }

    [CascadingParameter]
    [NotNull]
    private ContextMenu? ContextMenu { get; set; }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    protected override void OnInitialized()
    {
        base.OnInitialized();

        ContextMenu.AddItem(this);
    }

    private bool disposedValue;

    /// <summary>
    /// 释放资源方法
    /// </summary>
    /// <param name="disposing"></param>
    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                ContextMenu.RemoveItem(this);
            }
            disposedValue = true;
        }
    }

    /// <summary>
    /// <inheritdoc/>
    /// </summary>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}