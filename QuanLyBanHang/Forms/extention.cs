using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace QuanLyBanHang.Forms
{
    
        public static class StringExtensions
        {
            public static string GenerateSlug(this string input)
            {
                if (string.IsNullOrWhiteSpace(input))
                    return string.Empty;

                // bỏ dấu tiếng Việt
                string normalized = input.Normalize(NormalizationForm.FormD);
                StringBuilder sb = new StringBuilder();

                foreach (char c in normalized)
                {
                    if (Char.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.NonSpacingMark)
                        sb.Append(c);
                }

                string slug = sb.ToString().Normalize(NormalizationForm.FormC);

                // về lowercase
                slug = slug.ToLowerInvariant();

                // bỏ ký tự đặc biệt, chỉ giữ a-z 0-9 và khoảng trắng
                slug = Regex.Replace(slug, @"[^a-z0-9\s-]", "");

                // gộp nhiều khoảng trắng / dấu -
                slug = Regex.Replace(slug, @"[\s-]+", "-").Trim('-');

                return slug;
            }
        }

    
}
