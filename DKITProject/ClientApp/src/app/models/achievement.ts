export class Achievement {
    constructor(
        public Id: number,
        public Headline: string, 
        public Announce: string,
        public ImgPreview: string,
        public Content: string,
        public Images: string[]
    ){}
}