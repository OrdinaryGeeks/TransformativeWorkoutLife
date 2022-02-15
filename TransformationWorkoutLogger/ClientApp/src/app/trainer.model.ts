import { Training } from "./training.model";

export class Trainer {

  ID: string = '';
  Name: string = '';
  GuestID: string = '';
  IsValidated: boolean = false;

  MediaTop: boolean = true;
  MediaBottom: boolean = false;
  MediaLeft: boolean = false;
  MediaRight: boolean = false;
  MediaLink: string = '';
  Height: number = 0;
  Width: number = 0;
  Text: string = '';
  PostedDate: Date = new Date(1900, 1, 1);
  TrainingPages: Training[] = [];
  Image: boolean = false;
  Video: boolean = false;
  constructor(ID: string, Name: string, IsValidated: boolean,
  
    MediaTop: boolean, MediaBottom: boolean, MediaLeft: boolean, MediaRight: boolean, Image: boolean, Video: boolean,
    MediaLink: string, Height: number, Width: number, Text: string, PostedDate: Date, GuestID:string, TrainingPages: Training[]) {
    this.ID = ID;
    this.GuestID = GuestID;
    this.Image = Image;
    this.Video = Video;
    this.TrainingPages = TrainingPages;

    this.Name = Name;
    this.IsValidated = IsValidated;
   

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
