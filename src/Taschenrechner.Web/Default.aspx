<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Taschenrechner.Web._Default" %>

<body>
    <div class="calc-window">
        <div class="calc-label-wrapper">
            <div class="calc-label">
                123456789
            </div>
        </div>
        <div class="history-wrapper">
        </div>
        <div class="buttons-wrapper">
            <table class="buttons-table">
                <tr>
                    <td>
                        <button></button>
                    </td>
                    <td>
                        <button></button>
                    </td>
                    <td>
                        <button></button>
                    </td>
                    <td>
                        <button></button>
                    </td>
                </tr>
                <tr>
                    <td>
                        <button></button>
                    </td>
                    <td>
                        <button></button>
                    </td>
                    <td>
                        <button></button>
                    </td>
                    <td>
                        <button></button>
                    </td>
                </tr>
                <tr>
                    <td>
                        <button></button>
                    </td>
                    <td>
                        <button></button>
                    </td>
                    <td>
                        <button></button>
                    </td>
                    <td>
                        <button></button>
                    </td>
                </tr>
                <tr>
                    <td>
                        <button></button>
                    </td>
                    <td>
                        <button></button>
                    </td>
                    <td>
                        <button></button>
                    </td>
                    <td>
                        <button></button>
                    </td>
                </tr>
                <tr>
                    <td>
                        <button></button>
                    </td>
                    <td>
                        <button></button>
                    </td>
                    <td>
                        <button></button>
                    </td>
                    <td>
                        <button></button>
                    </td>
                </tr>
                <tr>
                    <td>
                        <button></button>
                    </td>
                    <td>
                        <button></button>
                    </td>
                    <td>
                        <button></button>
                    </td>
                    <td>
                        <button></button>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</body>

<style>
    body {
        background-color: #181926;
        font-family: 'Microsoft Sans Serif';
    }

    .calc-window {
        background-color: #24273a;
        position: absolute;
        width: 22%;
        height: 70%;
        z-index: 15;
        top: 50%;
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

    .buttons-wrapper {
        height: 48%;
        width: 90%;
        background-color: #363a4f;
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
        }

            .buttons-table td button {
                width: 100%;
                height: 100%;
                background-color: #6e738d;
                border-radius: 0.6vh;
                border: none;
            }
</style>
