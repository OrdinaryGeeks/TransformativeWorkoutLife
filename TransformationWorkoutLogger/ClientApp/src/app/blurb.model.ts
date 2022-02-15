export class Blurb {



  ID: string = "";
  MediaTop: boolean = true;
  MediaBottom: boolean = false;
  MediaLeft: boolean = false;
  MediaRight: boolean = false;
  MediaLink: string = '';
  Height: number = 0;
  Width: number = 0;
  Text: string = '';
  OwnerID: string = '';
  PostedDate: Date = new Date(1900, 1, 1);

  constructor(ID: string, MediaTop: boolean, MediaBottom: boolean, MediaLeft: boolean, MediaRight: boolean,
    MediaLink:string, Height: number, Width: number, Text: string, OwnerID: string, PostedDate: Date) {

    this.ID = ID;
    this.MediaTop = MediaTop;
    this.MediaBottom = MediaBottom;
    this.MediaLeft = MediaLeft;
    this.MediaRight = MediaRight;
    this.MediaLink = MediaLink;
    this.Height = Height;
    this.Width = Width;
    this.Text = Text;
    this.OwnerID = OwnerID;
    this.PostedDate = PostedDate;

  }
}
