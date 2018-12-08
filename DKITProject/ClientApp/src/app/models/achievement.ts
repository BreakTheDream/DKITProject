export class Achievement {
    constructor(
        public id: number,
        public headline: string, 
        public announce: string,
        public imgPreview: string,
        public content: string,
        public images: string[]
    ){}
}