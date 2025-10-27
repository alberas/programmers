<%@ Page Title="About" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.vb" Inherits="Programmers.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <style>
            div[data-val]{
                border:solid 1px black;
                width:15px;
                height:15px;
            }
            div[data-val='0']{
                background-color: white;
            }
            div[data-val='1']{
                background-color: red;
            }
        </style>
        <div>
            <div style="display:flex;flex-direction: row">
                <div id="initialBoard" style="display:grid;margin-right: 15px">
                </div>
                <div id="resultBoard" style="display:grid;">
                </div>
            </div>
            <input type="button" value="Next" onclick="CreateTwin()"/>
        </div>

        <script>
            const size = 5;
            const initialBoard = document.getElementById("initialBoard");
            const resultBoard = document.getElementById("resultBoard");
            window.addEventListener("load", () => {
                initialBoard.style.gridTemplateColumns = "repeat(" + size + ",15px)";
                resultBoard.style.gridTemplateColumns = "repeat(" + size + ",15px)";
                for (let x = 0; x < size; x++) {
                    for (let y = 0; y < size; y++) {
                        initialBoard.appendChild(CreateDv(x,y,1));
                    }
                }
            })
            
            const CreateTwin = () => {

                resultBoard.innerHTML = "";

                for (let x = 0; x < size; x++) {
                    for (let y = 0; y < size; y++) {
                        let dv = document.querySelector("#initialBoard > div[data-pos-x='" + x + "'][data-pos-y='" + y + "']");
                        let aliveNeighbours = GetQtAllNeighbours(dv).filter(cell => {
                            return (cell != null && cell.dataset.val == "1");
                        });
                        let deadNeighbours = GetQtAllNeighbours(dv).filter(cell => {
                            return (cell != null && cell.dataset.val == "0");
                        });


                        let val = dv.dataset.val;

                        if (val == "1" && aliveNeighbours.length < 2) {
                            val = "0";
                        }
                        if (val == "1" && (aliveNeighbours.length == 2 || aliveNeighbours.length == 3)) {
                            val = "1";
                        }
                        if (val == "1" && aliveNeighbours.length > 3) {
                            val = "1";
                        }
                        if (val == "0" && aliveNeighbours.length == 3) {
                            val = "1";
                        }
                        resultBoard.appendChild(CreateDv(x, y, val));

                    }
                }
            };

            function GetQtAllNeighbours(dv) {
                let x = new Number(dv.dataset.posX);
                let y = new Number(dv.dataset.posY);

                let yPlus1 = y + 1;
                let xPlus1 = x + 1;
                
                let neighbours = [
                    document.querySelector("#initialBoard > div[data-pos-x='" + (x - 1) + "'][data-pos-y='" + (y - 1) + "']"),
                    document.querySelector("#initialBoard > div[data-pos-x='" + (x - 1) + "'][data-pos-y='" + y + "']"),
                    document.querySelector("#initialBoard > div[data-pos-x='" + (x - 1) + "'][data-pos-y='" + yPlus1 + "']"),
                    document.querySelector("#initialBoard > div[data-pos-x='" + x + "'][data-pos-y='" + (y - 1) +"']"),
                    document.querySelector("#initialBoard > div[data-pos-x='" + x + "'][data-pos-y='" + yPlus1 +"']"),
                    document.querySelector("#initialBoard > div[data-pos-x='" + xPlus1 + "'][data-pos-y='" + (y - 1) +"']"),
                    document.querySelector("#initialBoard > div[data-pos-x='" + xPlus1 + "'][data-pos-y='" + y +"']"),
                    document.querySelector("#initialBoard > div[data-pos-x='" + xPlus1 + "'][data-pos-y='" + yPlus1 +"']")
                    
                ];


                return neighbours;
            }

            function CreateDv(x,y,val) {
                let dv = document.createElement("div");
                dv.dataset.posX = x;
                dv.dataset.posY = y;
                dv.dataset.val = val;
                dv.addEventListener("click", (e) => {
                    if (e.currentTarget.dataset.val == "1") {
                        e.currentTarget.dataset.val = "0";
                    } else {
                        e.currentTarget.dataset.val = "1";
                    }
                    //GetQtAllNeighbours(e.currentTarget)
                })

                return dv;
            }
            

        </script>
    </main>
</asp:Content>
