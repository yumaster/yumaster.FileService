﻿using ImageMagick;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using yumaster.FileService.Service.Models;

namespace yumaster.FileService.Service.ServiceImpls
{
    public class MagickImageConverter : QueuingImageConverter
    {
        protected override Task OnConvertAsync(string srcFilePath, Mime srcMime, string dstFilePath, ImageModifier dstImgMod, TaskContext taskCtx)
        {
            return Task.Run(() =>
            {
                Exception eError = null;
                try
                {
                    //dstFilePath是任务唯一ID，是判断任务已完成的标志，因此不能存在未完全完成的文件
                    //转换完成前先用临时文件名
                    var dstTmpFilePath = $"{dstFilePath}.cvting.{dstImgMod.Mime.ExtensionNames.First()}";

                    using (var img = new MagickImage(srcFilePath))
                    {
                        img.Thumbnail(dstImgMod.Size.Width, dstImgMod.Size.Height);

                        //magick会自动根据扩展名决定文件格式
                        img.Write(dstTmpFilePath);
                    }

                    File.Move(dstTmpFilePath, dstFilePath);
                }
                catch (Exception ex)
                {
                    eError = ex;
                }
                finally
                {
                    taskCtx.Complete(eError);
                }
            });
        }
    }
}
