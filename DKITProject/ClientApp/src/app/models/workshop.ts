export class Workshop {
    constructor(
        public Id: number,
        public Headline: string,
        public Announce: string,  
        public Content: string,
        public ImgIcon: string,
        public ImgPreview: string,
        public DatePost: Date,
        public DateStart: Date,
        public DateEnd: Date,
        public Count: number
    ) {}
}