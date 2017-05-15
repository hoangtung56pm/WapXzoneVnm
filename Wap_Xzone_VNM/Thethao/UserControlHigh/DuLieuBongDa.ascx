<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DuLieuBongDa.ascx.cs" Inherits="WapXzone_VNM.Thethao.UserControlHigh.DuLieuBongDa" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>

<div class="tonghop-video">
            <div class="title-video">
                <span style="color: #FF7E00;font-weight: 600;text-transform: uppercase;">
                    Dữ liệu bóng đá
                </span>
                <div class="border-color">
                    <div></div>
                </div>
            </div>
            <ul class="list-video-tonghop">
                <li><a href="<%= UrlProcess.TheThaoThongKeDacBiet() %>">Thống kê đặc biệt</a></li>
                <li><a href="<%= UrlProcess.TheThaoKetQuaHomNay() %>">Kết quả hôm nay</a></li>
                <li><a href="<%= UrlProcess.TheThaoLichThiDauHomNay() %>">Lịch thi đấu hôm nay</a></li>
                <li><a href="<%= UrlProcess.TheThaoLichThiDau() %>">Lịch thi đấu</a></li>
                <li><a href="<%= UrlProcess.TheThaoKetQuaThiDau() %>">Kết quả thi đấu</a></li>
                <li><a href="<%= UrlProcess.TheThaoBangXepHang() %>">Bảng xếp hạng</a></li>
            </ul>
        </div>