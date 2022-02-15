
export class Admin {

  ID: string = '';
  Name: string = '';
  IsValidated: boolean = false;
  IsSuperAdmin: boolean = false;
  FBLink: string = '';
  IGLink: string = '';
  SCLink: string = '';
  YTLink: string = '';
  MediaTop: boolean = true;
  MediaBottom: boolean = false;
  MediaLeft: boolean = false;
  MediaRight: boolean = false;
  MediaLink: string = '';
  Height: number = 0;
  Width: number = 0;
  Text: string = '';
  PostedDate: Date = new Date(1900, 1, 1);
  Image: boolean = false;
  Video: boolean = false;
  constructor(ID: string, Name: string, IsValidated: boolean, IsSuperAdmin: boolean,
    fbLink: string, igLink: string, scLink: string,
    ytLink: string,
    MediaTop: boolean, MediaBottom: boolean, MediaLeft: boolean, MediaRight: boolean, Image: boolean, Video: boolean,
    MediaLink: string, Height: number, Width: number, Text: string, PostedDate: Date){
    this.ID = ID;
    this.Image = Image;
    this.Video = Video;
    this.FBLink = fbLink;
    this.IGLink = igLink;
    this.SCLink = scLink;
    this.YTLink = ytLink;
    this.Name = Name;
    this.IsValidated = IsValidated;
    this.IsSuperAdmin = IsSuperAdmin;

    this.MediaTop = MediaTop;
    this.MediaBottom = MediaBottom;
    this.MediaLeft = MediaLeft;
    this.MediaRight = MediaRight;
    this.MediaLink = MediaLink;
    this.Height = Height;
    this.Width = Width;
    this.Text = Text;
    this.PostedDate = PostedDate;
  }


}
