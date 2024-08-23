<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Taschenrechner.Web._Default" %>
<!DOCTYPE html>

<input type="hidden" id="currentCalculationField" runat="server" />

<head runat="server">
    <title>Calculator</title>
    <script "text/javascript">
        function setDarkTheme() {
            document.documentElement.style.setProperty('--calc-label', '#494d64')
            document.documentElement.style.setProperty('--history-wrapper', '#363a4f')
            document.documentElement.style.setProperty('--subtext', '#a5adcb')
            document.documentElement.style.setProperty('--bg', '#181926')
            document.documentElement.style.setProperty('--calc-bg', '#24273a');
            document.documentElement.style.setProperty('--button-bg', '#494d64');
            document.documentElement.style.setProperty('--button-bg-hover', '#595e7d')
            document.documentElement.style.setProperty('--text', '#f4f4f4');
            document.documentElement.style.setProperty('--accent-color', '#c6a0f6');
            document.documentElement.style.setProperty('--accent-color-hover', '#d0aefa');
            document.documentElement.style.setProperty('--theme-toggle', '#dce0e8')
            document.getElementById('<%= hdnTheme.ClientID %>').value = 'dark';
        }
        function setLightTheme() {
            document.documentElement.style.setProperty('--bg', '#dce0e8')
            document.documentElement.style.setProperty('--calc-label', '#bcc0cc')
            document.documentElement.style.setProperty('--history-wrapper', '#ccd0da')
            document.documentElement.style.setProperty('--subtext', '#5c5f77')
            document.documentElement.style.setProperty('--calc-bg', '#f0f0f0');
            document.documentElement.style.setProperty('--button-bg', '#ccd0da');
            document.documentElement.style.setProperty('--button-bg-hover', '#adb4c4')
            document.documentElement.style.setProperty('--text', '#4c4f69');
            document.documentElement.style.setProperty('--accent-color', '#8839ef');
            document.documentElement.style.setProperty('--accent-color-hover', '#7550cb');
            document.documentElement.style.setProperty('--theme-toggle', '#181926')
            document.getElementById('<%= hdnTheme.ClientID %>').value = 'light';
        }
    </script>
</head>

<body>
    <form id="form1" runat="server">
        <asp:HiddenField ID="hdnTheme" runat="server" Value="dark" />

        <asp:Panel ID="CalcWindow" runat="server" CssClass="calc-window">
            <asp:Panel ID="LabelWrapper" runat="server" CssClass="calc-label-wrapper">
                <asp:Label ID="CalcLabel" runat="server" CssClass="calc-label"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="HistoryWrapper" runat="server" CssClass="history-wrapper">
                <asp:Button ID="ClearHistoryButton" runat="server" CssClass="clear-history-button" EnableTheming="False" OnClick="ClearHistoryButton_Click" />
                <asp:Label ID="HistoryBox" runat="server" CssClass="history-box"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="ButtonsWrapper" runat="server" CssClass="buttons-wrapper">
                <table class="buttons-table" style="width: 100%;">
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button ID="ButtonC" runat="server" CssClass="calc-button" Text="C" OnClick="ButtonC_Click" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonCE" runat="server" CssClass="calc-button" Text="CE" OnClick="ButtonCE_Click" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonBack" runat="server" CssClass="calc-button" Text="←" OnClick="ButtonBack_Click" />
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="ButtonPower" runat="server" CssClass="calc-button" Text="^" OnClick="ButtonPower_Click" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonParenthesisLeft" runat="server" CssClass="calc-button" Text="(" OnClick="ButtonParenthesisLeft_Click" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonParenthesisRight" runat="server" CssClass="calc-button" Text=")" OnClick="ButtonParenthesisRight_Click" />
                        </td>
                        <td>
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
                        <td>
                            <asp:Button ID="Button9" runat="server" CssClass="calc-button" Text="9" OnClick="Button9_Click" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonMultiply" runat="server" CssClass="calc-button" Text="×" OnClick="ButtonMultiply_Click" />
                        </td>

                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Button4" runat="server" CssClass="calc-button" Text="4" OnClick="Button4_Click" />
                        </td>
                        <td>
                            <asp:Button ID="Button5" runat="server" CssClass="calc-button" Text="5" OnClick="Button5_Click" />
                        </td>
                        <td>
                            <asp:Button ID="Button6" runat="server" CssClass="calc-button" Text="6" OnClick="Button6_Click" />
                        </td>
                        <td>
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
                        <td>
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
                        <td>
                            <asp:Button ID="ButtonDecimal" runat="server" CssClass="calc-button" Text="." OnClick="ButtonDecimal_Click" />
                        </td>
                        <td>
                            <asp:Button ID="ButtonEvaluate" runat="server" CssClass="calc-button" Text="=" OnClick="ButtonEvaluate_Click" />
                        </td>

                    </tr>
                </table>
            </asp:Panel>
        </asp:Panel>
        <asp:Button ID="ThemeToggle" runat="server" CssClass="theme-toggle" OnClick="ThemeToggle_Click" />
    </form>
</body>



<style>
    :root {
        --bg: #181926;
        --calc-bg: #24273a;
        --calc-label: #494d64;
        --subtext: #5c5f77;
        --history-wrapper: #363a4f;
        --button-bg: #494d64;
        --button-bg-hover: #595e7d;
        --text: #f4f4f4;
        --accent-color: #c6a0f6;
        --accent-color-hover: #d0aefa;
        --theme-toggle: #dce0e8;
    }

    body {
        background-color: var(--bg);
        font-family: 'Microsoft Sans Serif';
    }

    .calc-window {
        background-color: var(--calc-bg);
        position: absolute;
        width: 296px;
        height: 472px;
        z-index: 15;
        top: 54%;
        left: 50%;
        margin: -19% 0 0 -11%;
        border-radius: 2vh;
    }

    .calc-label-wrapper {
        height: 10%;
        width: 90%;
        background-color: var(--calc-label);
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
        color: var(--text);
        overflow: hidden;
    }

    .history-wrapper {
        height: 30%;
        width: 90%;
        background-color: var(--history-wrapper);
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
        height: 90%;
        color: var(--subtext);
        padding: 5px 10px;
        overflow: hidden;
        line-height: 120%;
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

    .clear-history-button {
        height: 3vh;
        width: 4vh;
        margin: 1vh;
        padding: 0;
        border-radius: 30%;
        background-color: var(--accent-color);
        border: none;
        display: inline-block;
    }

        .clear-history-button:hover {
            scale: 95%;
        }

        .clear-history-button:active {
            scale: 93%;
        }


    #ButtonEvaluate {
        background-color: var(--accent-color);
        color: white;
    }

        #ButtonEvaluate:hover {
            background-color: var(--accent-color-hover);
        }

    .calc-button {
        width: 100%;
        height: 100%;
        border-radius: 0.6vh;
        border: none;
        background-color: var(--button-bg);
        color: var(--text);
    }

        .calc-button:hover {
            background-color: var(--button-bg-hover);
        }

        .calc-button:active {
            scale: 90%;
        }

    .theme-toggle {
        background-color: var(--theme-toggle);
        position: absolute;
        width: 40px;
        height: 40px;
        bottom: 2vw;
        left: 2vw;
        border-radius: 100%;
        border: none;
        transition: 0.3s ease;
    }
    .theme-toggle:hover {
        scale: 200%;
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
