namespace Samples

open WebSharper
open WebSharper.Cytoscape
open WebSharper.JavaScript
open WebSharper.UI
open WebSharper.UI.Html
open WebSharper.UI.Client

[<JavaScript>]
module HelloWorld =

    [<SPAEntryPoint>]
    let Main () =
        let cy = 
            Cytoscape(
                CytoscapeOptions(
                    Container = JS.Document.GetElementById "main",
                    Style = 
                        [|
                            StyleConfig(
                                selector = "node",
                                style = New [
                                    "shape" => "data(faveShape)"
                                    "width" => "mapData(weight, 40, 80, 20, 60)"
                                    "content" => "data(name)"
                                    "text-valign" => "center"
                                    "text-outline-width" => 2
                                    "text-outline-color" => "data(faveColor)"
                                    "background-color" => "data(faveColor)"
                                    "color" => "#FFF"
                                ]
                            )
                            StyleConfig(
                                selector = ":selected",
                                style = New [
                                    "border-width" => 3
                                    "border-color" => "#333"
                                ]
                            )
                            StyleConfig(
                                selector = "edge",
                                style = New [
                                    "curve-style" => "bezier"
                                    "opacity" => 0.666
                                    "width" => "mapData(strength, 70, 100, 2, 6)"
                                    "target-arrow-shape" => "triangle"
                                    "source-arrow-shape" => "circle"
                                    "line-color" => "data(faveColor)"
                                    "source-arrow-color" => "data(faveColor)"
                                    "target-arrow-color" => "data(faveColor)"
                                ]
                            )
                            StyleConfig(
                                selector = "edge.questionable",
                                style = New [
                                    "line-style" => "dotted"
                                    "target-arrow-shape" => "diamond"
                                ]
                            )
                            StyleConfig(
                                selector = ".faded",
                                style = New [
                                    "opacity" => 0.25
                                    "text-opacity" => 0
                                ]
                            )
                        |],
                    Elements =
                        [|
                            ElementObject(Data = ElementData(Id = "j", Name="Jerry", Weight=65., FaveColor="#6FB1FC", FaveShape="triangle"))
                            ElementObject(Data = ElementData(Id = "e", Name="Elanie", Weight=45., FaveColor="#EDA1ED", FaveShape="ellipse"))
                            ElementObject(Data = ElementData(Id = "k", Name="Kramer", Weight=75., FaveColor="#86B342", FaveShape="octagon"))
                            ElementObject(Data = ElementData(Id = "g", Name="George", Weight=70., FaveColor="#F5A45D", FaveShape="rectangle"))
                            
                            ElementObject(Data = ElementData(Source = "j", Target = "e", FaveColor = "#6FB1FC", Strength = 90.))
                            ElementObject(Data = ElementData(Source = "j", Target = "k", FaveColor = "#6FB1FC", Strength = 70.))
                            ElementObject(Data = ElementData(Source = "j", Target = "g", FaveColor = "#6FB1FC", Strength = 80.))
                        
                            ElementObject(Data = ElementData(Source = "e", Target = "j", FaveColor = "#EDA1ED", Strength = 95.))
                            ElementObject(Data = ElementData(Source = "e", Target = "k", FaveColor = "#EDA1ED", Strength = 60.), Classes = "questionable")
                            
                            ElementObject(Data = ElementData(Source = "k", Target = "j", FaveColor = "#86B342", Strength = 100.))
                            ElementObject(Data = ElementData(Source = "k", Target = "e", FaveColor = "#86B342", Strength = 100.))
                            ElementObject(Data = ElementData(Source = "k", Target = "g", FaveColor = "#86B342", Strength = 100.))
                        
                            ElementObject(Data = ElementData(Source = "g", Target = "j", FaveColor = "#F5A45D", Strength = 90.))
                        |],
                    Layout = LayoutOptions(
                            Name = "cose",
                            Padding = 10
                        )
                )
            )
            
        ()
