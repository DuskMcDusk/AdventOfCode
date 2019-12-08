open System

let stringToIntArray (input: string) = 
    input.Split (',')
    |> Array.map Convert.ToInt32
   
let loadData filePath = 
    System.IO.File.ReadAllText filePath
    |> stringToIntArray


let operate (array: int[]) positions operation = 
    let first, second, destination = positions
    let result = operation array.[first] array.[second]
    Array.set array destination result
    array
let add (array: int[]) positions =
    operate array positions (+)
let multiply (array: int[]) positions =
    operate array positions (*)

let fetchChunk index (array: int[]) =
   (array.[index+1], array.[index+2], array.[index+3]) 

let rec handleInput index (array: int[])  =
    let operate action = 
        fetchChunk index array 
        |> action array
        |> handleInput (index + 4)
    match  array.[index] with
    | 1 -> operate add
    | 2 -> operate multiply
    | 99 -> array
    | _ -> failwith "invalid input"

let prepareInput data = 
    Array.set data 1 12
    Array.set data 2 2
    data