<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Taschenrechner.Web._Default" %>
<input type="hidden" id="currentCalculationField" runat="server" />
<body style="height: 99px">
    <form id="form1" runat="server">
        <asp:Panel ID="CalcWindow" runat="server" CssClass="calc-window">
            <asp:Panel ID="LabelWrapper" runat="server" CssClass="calc-label-wrapper">
                <asp:Label ID="CalcLabel" runat="server" CssClass="calc-label"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="HistoryWrapper" runat="server" CssClass="history-wrapper"> 
                <asp:Label ID="HistoryBox" runat="server" CssClass="history-box" Text="Label"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="ButtonsWrapper" runat="server" CssClass="buttons-wrapper">
                <table class="buttons-table" style="width: 100%;">
                    <tr>
                        <td class="auto-style2"></td>
                        <td class="auto-style2">
                            <asp:Button ID="ButtonC" runat="server" CssClass="calc-button" Text="C" OnClick="ButtonC_Click" />
                        </td>
                        <td class="auto-style3">
                            <asp:Button ID="ButtonCE" runat="server" CssClass="calc-button" Text="CE" OnClick="ButtonCE_Click" />
                        </td>
                        <td class="auto-style2">
                            <asp:Button ID="ButtonBack" runat="server" CssClass="calc-button" Text="←" OnClick="ButtonBack_Click" />
                        </td>

                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Button ID="ButtonPower" runat="server" CssClass="calc-button" Text="^" OnClick="ButtonPower_Click" />
                        </td>
                        <td class="auto-style2">
                            <asp:Button ID="ButtonParenthesisLeft" runat="server" CssClass="calc-button" Text="(" OnClick="ButtonParenthesisLeft_Click" />
                        </td>
                        <td class="auto-style1">
                            <asp:Button ID="ButtonParenthesisRight" runat="server" CssClass="calc-button" Text=")" OnClick="ButtonParenthesisRight_Click" />
                        </td>
                        <td class="auto-style2">
                            <asp:Button ID="ButtonDivide" runat="server" CssClass="calc-button" Text="÷" OnClick="ButtonDivide_Click" />
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Button7" runat="server" CssClass="calc-button" Text="7" OnClick="Button7_Click" />
                        </td>
                        <td>
                            <asp:Button ID="Button8" runat="server" CssClass="calc-button" Text="8" OnClick="Button8_Click" />
                        </td>
                        <td class="auto-style1">
                            <asp:Button ID="Button9" runat="server" CssClass="calc-button" Text="9" OnClick="Button9_Click"/>
                        </td>
                        <td>
                            <asp:Button ID="ButtonMultiply" runat="server" CssClass="calc-button" Text="×" OnClick="ButtonMultiply_Click" />
                        </td>

                    </tr>
                    <tr>
                        <td class="auto-style3">
                            <asp:Button ID="Button4" runat="server" CssClass="calc-button" Text="4" OnClick="Button4_Click" />
                        </td>
                        <td class="auto-style3">
                            <asp:Button ID="Button5" runat="server" CssClass="calc-button" Text="5" OnClick="Button5_Click" />
                        </td>
                        <td class="auto-style1">
                            <asp:Button ID="Button6" runat="server" CssClass="calc-button" Text="6" OnClick="Button6_Click" />
                        </td>
                        <td class="auto-style3">
                            <asp:Button ID="ButtonMinus" runat="server" CssClass="calc-button" Text="-" OnClick="ButtonMinus_Click" />
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Button1" runat="server" CssClass="calc-button" Text="1" OnClick="Button1_Click" />
                        </td>
                        <td>
                            <asp:Button ID="Button2" runat="server" CssClass="calc-button" Text="2" OnClick="Button2_Click" />
                        </td>
                        <td class="auto-style1">
                            <asp:Button ID="Button3" runat="server" CssClass="calc-button" Text="3" OnClick="Button3_Click" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonPlus" runat="server" CssClass="calc-button" Text="+" OnClick="ButtonPlus_Click" />
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="ButonToggleSign" runat="server" CssClass="calc-button" Text="+/-" OnClick="ButtonToggleSign_Click" />
                        </td>
                        <td>
                            <asp:Button ID="Button0" runat="server" CssClass="calc-button" Text="0" OnClick="Button0_Click" />
                        </td>
                        <td class="auto-style1">
                            <asp:Button ID="ButtonDecimal" runat="server" CssClass="calc-button" Text="." OnClick="ButtonDecimal_Click" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonEvaluate" runat="server" CssClass="calc-button" Text="=" OnClick="ButtonEvaluate_Click" />
                        </td>

                    </tr>
                </table>
            </asp:Panel>
        </asp:Panel>
    </form>
</body>

<style>
    body {
        background-color: #181926;
        font-family: 'Microsoft Sans Serif';
    }

    .calc-window {
        background-color: #24273a;
        position: absolute;
        width: 296px;
        height: 472px;
        z-index: 15;
        top: 54%;
        left: 50%;
        margin: -19% 0 0 -11%;
        box-shadow: 0 0 10vh #10101A;
        border-radius: 2vh;
    }

    .calc-label-wrapper {
        height: 10%;
        width: 90%;
        background-color: #494d64;
        margin: 5%;
        border-radius: 1vh;
        text-align: right;
        display: flex;
        align-items: center;
        justify-content: flex-end;
    }

    .calc-label {
        padding-right: 2vh;
        font-size: 170%;
        color: #cad3f5;
    }

    .history-wrapper {
        height: 30%;
        width: 90%;
        background-color: #363a4f;
        margin: 5%;
        border-radius: 1vh;
        display: flex;
        text-align: right;
        justify-content: flex-end;
    }

    .history-box {
        background: none;
        border: none;
        width: 100%;
        height: 100%;
        color: #a5adcb;
        padding: 5px 10px;
    }

    .buttons-wrapper {
        height: 48%;
        width: 90%;
        margin: 5%;
        border-radius: 1vh;
        overflow: hidden;
    }

    .buttons-table {
        height: 100%;
        width: 100%;
        border: none;
        border-spacing: 0;
    }

        .buttons-table td {
            padding: 0.2vh;
            margin: 0;
            background: none !important;
            border: none;
            width: 25%;
        }

    #ButtonEvaluate {
        background-color: #c6a0f6;
        color: white;
    }

    .calc-button {
        width: 100%;
        height: 100%;
        border-radius: 0.6vh;
        border: none;
        background-color: #494d64;
        color: #cad3f5
    }

    .auto-style1 {
        width: 62px;
    }
    .auto-style2 {
        height: 37px;
    }
    .auto-style3 {
        width: 62px;
        height: 37px;
    }
    </style>
