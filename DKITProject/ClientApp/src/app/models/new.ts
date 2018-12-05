export class New {
    constructor(
        public Id: number,
        public Headline: string,
        public Announce: string,
        public Content: string,
        public ImgPreview: string,
        public Images: string[],
        public DatePost: Date
    ){}
}