export interface Portfolio {
  id: string,
  createdTime: string,
  fields: Fields[]
}

export interface Fields {
  title: string,
  subtitle: string,
  location: string,
  client: string[],
  size: string,
  project: string,
  sf: number,
  role: string[],
  writeUp: string,
  active: boolean,
  constructionStatus: boolean,
  clientName: string
}
/*
export interface Thumb {
  id: string,
  url: string,
  filename: string,
  size: number,
  type: string
}
*/
//public IList < Thumb > thumb { get; set; }