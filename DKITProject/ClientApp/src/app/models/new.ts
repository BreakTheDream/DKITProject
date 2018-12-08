export class New {
    constructor(
        public id: number,
        public headline: string,
        public announce: string,
        public content: string,
        public imgPreview: string,
        public images: string[],
        public datePost: Date
    ){}
}

export class NewPreview {
    constructor(
        public id: number,
        public headline: string,
        public announce: string,
        public imgPreview: string,
        public datePost: Date
    ){}
}