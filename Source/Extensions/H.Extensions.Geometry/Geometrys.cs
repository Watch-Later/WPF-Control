﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Markup;

namespace H.Extensions.Geometry
{
    public class Geometrys
    {
        public const string Close = "F1M8.583,8L13,12.424 12.424,13 8,8.583 3.576,13 3,12.424 7.417,8 3,3.576 3.576,3 8,7.417 12.424,3 13,3.576z";
        public const string Restore = "F1M11.999,10.002L10.998,10.002 10.998,5.002 5.998,5.002 5.998,4.001 11.999,4.001z M10.002,11.999L4.001,11.999 4.001,5.998 10.002,5.998z M5.002,3L5.002,5.002 3,5.002 3,13 10.998,13 10.998,10.998 13,10.998 13,3z";
        public const string Maximize = "F1M12,12L4,12 4,4 12,4z M3,13L13,13 13,3 3,3z";
        public const string Minimize = "F1M3,8L13,8 13,7 3,7z";
        public const string Down = "M 0 0 L 4 4 L 8 0 Z";
        public const string Up = "M 0 4 L 4 0 L 8 4 Z";
        public const string Right = "M 0 0 L 4 4 L 0 8 Z";
        public const string Left = "M 4 0 L 0 4 L 4 8 Z";
        public const string Warn = "M947.2 810.666667L571.733333 128C554.666667 100.266667 533.333333 85.333333 509.866667 85.333333c-23.466667 0-44.8 14.933333-59.733334 42.666667L74.666667 810.666667c-14.933333 25.6-14.933333 53.333333-4.266667 74.666666 12.8 21.333333 36.266667 32 66.133333 32h746.666667c29.866667 0 53.333333-12.8 66.133333-32 12.8-21.333333 12.8-49.066667-2.133333-74.666666z m-34.133333 51.2c-4.266667 6.4-14.933333 10.666667-29.866667 10.666666h-746.666667c-14.933333 0-25.6-4.266667-29.866666-10.666666-4.266667-6.4-2.133333-19.2 4.266666-32l375.466667-682.666667c8.533333-12.8 17.066667-19.2 23.466667-19.2 6.4 0 14.933333 6.4 23.466666 19.2l375.466667 682.666667c8.533333 12.8 8.533333 25.6 4.266667 32z M512 640c12.8 0 21.333333-8.533333 21.333333-21.333333V322.133333c0-12.8-8.533333-21.333333-21.333333-21.333333s-21.333333 8.533333-21.333333 21.333333V618.666667c0 10.666667 10.666667 21.333333 21.333333 21.333333z M509.866667 744.533333m-42.666667 0a42.666667 42.666667 0 1 0 85.333333 0 42.666667 42.666667 0 1 0-85.333333 0Z";
        public const string Success = "M512 1013.76c-277.11488 0-501.76-224.64512-501.76-501.76S234.88512 10.24 512 10.24s501.76 224.64512 501.76 501.76-224.64512 501.76-501.76 501.76z m0-51.02592c248.9344 0 450.73408-201.79968 450.73408-450.73408 0-248.9344-201.79968-450.73408-450.73408-450.73408-248.9344 0-450.73408 201.79968-450.73408 450.73408 0 248.9344 201.79968 450.73408 450.73408 450.73408z m-89.22112-361.0112c60.928-74.33216 195.9424-222.67904 382.08512-340.16256l15.616 37.4784c-171.14624 161.8944-311.36768 322.23744-355.45088 438.76864l-256.8704-201.6 65.82784-54.48704 148.7872 119.99744z";
        public const string Info = "M512 1024c-136.8 0-265.3-53.3-362-150C53.3 777.3 0 648.8 0 512s53.3-265.3 150-362C246.7 53.3 375.2 0 512 0s265.3 53.3 362 150c96.7 96.7 150 225.3 150 362 0 136.8-53.3 265.3-150 362-96.7 96.7-225.2 150-362 150z m0-979.5c-124.9 0-242.3 48.6-330.6 136.9C93.1 269.7 44.5 387.1 44.5 512s48.6 242.3 136.9 330.6c88.3 88.3 205.7 136.9 330.6 136.9 124.9 0 242.3-48.6 330.6-136.9 88.3-88.3 136.9-205.7 136.9-330.6 0-124.9-48.6-242.3-136.9-330.6C754.3 93.1 636.9 44.5 512 44.5z M480.8 244.3c0 17.2 14 31.2 31.2 31.2s31.2-14 31.2-31.2-14-31.2-31.2-31.2-31.2 14-31.2 31.2zM512 810.9c-12.2 0-22.3-10-22.3-22.3V387.9c0-12.2 10-22.3 22.3-22.3 12.2 0 22.3 10 22.3 22.3v400.7c0 12.3-10.1 22.3-22.3 22.3z";
        public const string Fatal = "M520.7 934c-59.8 0-117.8-11.7-172.5-34.8-52.8-22.3-100.1-54.3-140.8-94.9-40.7-40.7-72.6-88.1-94.9-140.8C89.4 608.8 77.7 550.8 77.7 491s11.7-117.8 34.8-172.5c22.3-52.8 54.3-100.1 94.9-140.8 40.7-40.7 88.1-72.6 140.8-94.9C402.9 59.7 460.9 48 520.7 48s117.8 11.7 172.5 34.8c52.8 22.3 100.1 54.3 140.8 94.9 40.7 40.7 72.6 88.1 94.9 140.8 23.1 54.6 34.8 112.7 34.8 172.5S952 608.8 928.9 663.5c-22.3 52.8-54.3 100.1-94.9 140.8-40.7 40.7-88.1 72.6-140.8 94.9-54.7 23.1-112.7 34.8-172.5 34.8z m0-842c-53.9 0-106.1 10.5-155.3 31.3-47.5 20.1-90.2 48.9-126.8 85.5-36.7 36.7-65.4 79.3-85.5 126.8-20.8 49.2-31.3 101.4-31.3 155.3s10.5 106.1 31.3 155.3c20.1 47.5 48.9 90.2 85.5 126.8 36.7 36.7 79.3 65.4 126.8 85.5 49.2 20.8 101.4 31.3 155.3 31.3s106.1-10.5 155.3-31.3c47.5-20.1 90.2-48.9 126.8-85.5s65.4-79.3 85.5-126.8c20.8-49.2 31.3-101.4 31.3-155.3s-10.5-106.1-31.3-155.3c-20.1-47.5-48.9-90.2-85.5-126.8-36.7-36.7-79.3-65.4-126.8-85.5C626.9 102.5 574.6 92 520.7 92z M520.7 458.6V210.3L400.4 523.4h120.3v248.3l100.1-260.4 20.2-52.7z";
        public const string Error = "M982.668821 313.74918c-25.810101-60.752236-62.714-115.373446-109.685763-162.346233-46.972787-46.971763-101.593997-83.875662-162.346233-109.685763C647.666853 14.966132 580.925912 1.401699 512.268258 1.401699S376.868639 14.966132 313.898667 41.717184c-60.752236 25.810101-115.373446 62.714-162.346233 109.685763-46.971763 46.972787-83.875662 101.593997-109.685763 162.346233C15.115619 376.719151 1.551186 443.460092 1.551186 512.118771S15.115619 647.517366 41.866671 710.487337c25.810101 60.75326 62.714 115.37447 109.685763 162.346233 46.971763 46.972787 101.592974 83.876686 162.346233 109.685763 62.969971 26.752076 129.710912 40.316509 198.369591 40.316509s135.398595-13.564433 198.368567-40.316509c60.75326-25.809077 115.37447-62.712976 162.346233-109.685763 46.972787-46.971763 83.876686-101.592974 109.685763-162.346233 26.752076-62.969971 40.316509-129.710912 40.316509-198.368567S1009.419873 376.719151 982.668821 313.74918zM937.435615 691.271058c-23.333323 54.923257-56.71096 104.317532-99.204249 146.811845-42.494313 42.493289-91.888588 75.870926-146.811845 99.204249-56.8584 24.155503-117.133505 36.403219-179.152287 36.403219-62.018782 0-122.293887-12.247716-179.152287-36.403219-54.923257-23.333323-104.317532-56.71096-146.810821-99.204249-42.493289-42.494313-75.870926-91.888588-99.204249-146.811845C62.944374 634.412658 50.697682 574.136529 50.697682 512.118771c0-62.018782 12.247716-122.293887 36.403219-179.152287 23.333323-54.923257 56.709936-104.317532 99.204249-146.810821s91.888588-75.870926 146.810821-99.204249c56.8584-24.155503 117.133505-36.403219 179.152287-36.403219 62.017758 0 122.292863 12.247716 179.152287 36.403219 54.923257 23.333323 104.317532 56.709936 146.810821 99.204249 42.494313 42.493289 75.870926 91.888588 99.205273 146.810821 24.155503 56.8584 36.403219 117.134529 36.403219 179.152287S961.591118 634.412658 937.435615 691.271058z M704.62457 319.769626c-9.997216-9.996192-26.203273-9.996192-36.199466 0L512.382933 475.810773 356.341786 319.769626c-9.996192-9.996192-26.204297-9.996192-36.199466 0-9.996192 9.996192-9.996192 26.203273 0 36.199466l156.041147 156.041147L320.14232 668.05241c-9.996192 9.997216-9.996192 26.204297 0 36.199466 4.997584 4.998608 11.549426 7.496888 18.100245 7.496888s13.101637-2.49828 18.100245-7.496888l156.041147-156.041147L668.424081 704.251876c4.998608 4.998608 11.548403 7.496888 18.100245 7.496888s13.101637-2.49828 18.100245-7.496888c9.996192-9.996192 9.996192-26.203273 0-36.199466L548.583423 512.011263l156.041147-156.041147C714.620762 345.973923 714.620762 329.765818 704.62457 319.769626z";
        public const string Wait = "M511.49 294.67c-16.57 0-30-13.43-30-30V129.21c0-16.57 13.43-30 30-30s30 13.43 30 30v135.46c0 16.57-13.44 30-30 30zM510.45 927.13c-16.57 0-30-13.43-30-30V761.67c0-16.57 13.43-30 30-30s30 13.43 30 30v135.46c0 16.57-13.43 30-30 30zM265.66 540.28H130.2c-16.57 0-30-13.43-30-30s13.43-30 30-30h135.46c16.57 0 30 13.43 30 30s-13.43 30-30 30zM892.81 540.28H757.35c-16.57 0-30-13.43-30-30s13.43-30 30-30h135.46c16.57 0 30 13.43 30 30s-13.43 30-30 30zM263.14 809.9c-7.68 0-15.36-2.93-21.21-8.79-11.72-11.72-11.72-30.71 0-42.43l95.79-95.79c11.72-11.72 30.71-11.72 42.43 0 11.72 11.72 11.72 30.71 0 42.43l-95.79 95.79c-5.86 5.86-13.54 8.79-21.22 8.79zM706.6 366.44c-7.68 0-15.36-2.93-21.21-8.79-11.72-11.72-11.72-30.71 0-42.43l95.79-95.79c11.71-11.71 30.71-11.71 42.43 0 11.72 11.72 11.72 30.71 0 42.43l-95.79 95.79c-5.86 5.86-13.54 8.79-21.22 8.79zM781.13 809.9c-7.68 0-15.35-2.93-21.21-8.79l-95.79-95.79c-11.72-11.72-11.72-30.71 0-42.43 11.72-11.72 30.71-11.71 42.43 0l95.79 95.79c11.72 11.72 11.72 30.71 0 42.43a29.95 29.95 0 0 1-21.22 8.79zM337.67 366.44c-7.68 0-15.35-2.93-21.21-8.79l-95.79-95.79c-11.72-11.72-11.72-30.71 0-42.43 11.72-11.72 30.71-11.71 42.43 0l95.79 95.79c11.72 11.72 11.72 30.71 0 42.43a29.933 29.933 0 0 1-21.22 8.79z";
        public const string Dalog = "M776.2 376.9H248v52.8h528.2v-52.8zM723.4 568.4H300.8v52.8h422.6v-52.8zM512.1 106.5c253.2 0 459.2 174.1 459.2 388.2 0 214-206 388.2-459.2 388.2-67.1 0-131.7-12-192.1-35.6-9.9-3.9-21.1-5.8-34.1-5.8-37.8 0-101.2 18.6-157.3 38.2 28.7-89.9 30.3-134.7 6.3-163.8-53.6-65.2-82-141.6-82-221.2 0-214.1 206-388.2 459.2-388.2m0-52.8c-282.8 0-512 197.4-512 441 0 94.9 34.8 182.8 94 254.7 24.7 30-55.1 221.1-55.1 221.1s182.1-76.2 246.9-76.2c6.1 0 11.1 0.7 14.9 2.1 64.4 25.2 136 39.2 211.3 39.2 282.8 0 512-197.4 512-441S794.9 53.7 512.1 53.7z";
        public const string Fixed = "M149.333333 896c-6.4 0-10.666667-2.133333-14.933333-6.4-8.533333-6.4-8.533333-19.2-2.133333-27.733333l238.933333-326.4-149.333333-149.333334c-4.266667-4.266667-6.4-8.533333-6.4-14.933333s2.133333-10.666667 6.4-14.933333c55.466667-55.466667 125.866667-64 206.933333-23.466667l243.2-134.4-12.8-89.6c-2.133333-8.533333 4.266667-17.066667 10.666667-21.333333 8.533333-4.266667 17.066667-2.133333 25.6 4.266666l236.8 236.8c6.4 6.4 8.533333 17.066667 4.266666 25.6-4.266667 8.533333-12.8 12.8-21.333333 10.666667l-89.6-12.8-134.4 243.2c27.733333 59.733333 46.933333 136.533333-23.466667 206.933333-8.533333 8.533333-21.333333 8.533333-29.866666 0l-149.333334-149.333333L162.133333 891.733333c-4.266667 2.133333-8.533333 4.266667-12.8 4.266667z m119.466667-522.666667l145.066667 145.066667c6.4 6.4 8.533333 19.2 2.133333 27.733333l-166.4 226.133334 226.133333-166.4c8.533333-6.4 21.333333-6.4 27.733334 2.133333l147.2 147.2c29.866667-40.533333 27.733333-85.333333-4.266667-151.466667-2.133333-6.4-2.133333-12.8 0-19.2l147.2-266.666666c4.266667-8.533333 12.8-12.8 21.333333-10.666667l40.533334 6.4-145.066667-145.066667 6.4 40.533334c2.133333 8.533333-2.133333 17.066667-10.666667 21.333333l-266.666666 147.2c-6.4 4.266667-14.933333 4.266667-21.333334 0-59.733333-34.133333-106.666667-36.266667-149.333333-4.266667z";
        public const string UnFixed = "M393.846 64.175l117.454 0.4h1.2l117.454-0.4-10.396 10.396c-18.893 18.892-28.489 44.982-26.29 71.472l20.292 250.502c3 36.686 18.093 72.172 42.484 99.661l34.186 38.685-122.252-0.9-55.478-0.4h-1l-55.478 0.4-122.452 0.8 34.186-38.685c24.39-27.589 39.485-62.975 42.484-99.66l20.292-250.403c2.199-26.59-7.397-52.68-26.29-71.472l-10.396-10.396M675.736 0h-0.2L512.4 0.6h-0.8L348.364 0h-0.2c-20.892 0-39.684 13.495-45.582 33.587-4.099 13.994-1.9 30.888 17.793 47.581l38.585 38.585a26.866 26.866 0 0 1 7.797 21.092l-20.292 250.402c-1.9 23.191-11.196 45.083-26.59 62.476l-61.876 69.872c-8.696 9.797-13.894 22.292-14.394 35.387-0.3 8.996 1.6 18.892 8.596 27.289 6.898 8.297 17.294 12.895 27.99 12.895h0.3l175.93-1.2 55.18 422.835 0.399 3.099 0.4-3.099 55.178-422.835 175.932 1.2h0.3c10.795 0 21.191-4.598 27.989-12.895 6.897-8.397 8.796-18.293 8.596-27.29-0.4-13.094-5.698-25.59-14.394-35.386l-61.876-69.872c-15.394-17.393-24.69-39.285-26.59-62.476l-20.292-250.402c-0.6-7.797 2.2-15.594 7.797-21.092l38.585-38.585c19.692-16.693 21.892-33.587 17.793-47.581C715.421 13.595 696.628 0 675.736 0z";
    }

    public class GemetrysSourceExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return typeof(Geometrys).GetFields().Select(x => x.GetValue(null));
        }
    }


}
