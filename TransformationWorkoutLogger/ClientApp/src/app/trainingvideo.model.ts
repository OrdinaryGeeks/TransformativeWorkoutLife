import { Schedule } from "./schedule.model";

export class TrainingVideo {


  ID: string = '';
  TrainingID: string = '';
  Back: boolean = false;
  Chest: boolean = false;
  Biceps: boolean = false;
  Triceps: boolean = false;
  Shoulders: boolean = false;
  ForeArms: boolean = false;
  Abs: boolean = false;
  Buttocks: boolean = false;
  Quadriceps: boolean = false;
  Hamstrings: boolean = false;
  Calves: boolean = false;

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

  constructor(ID: string,
    MediaTop: boolean, MediaBottom: boolean, MediaLeft: boolean, MediaRight: boolean,
    MediaLink: string, Height: number, Width: number,Image:boolean, Video:boolean, Text: string, PostedDate: Date, TrainingID: string) {
    this.ID = ID;
    this.TrainingID = TrainingID;
    this.Image = Image;
    this.Video = Video;
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
