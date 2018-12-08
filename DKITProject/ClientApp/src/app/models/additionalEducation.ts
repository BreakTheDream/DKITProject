export class AdditionalEducation {
    constructor(
        public id: number,
        public headline: string,
        public announce: string,  
        public content: string,
        public imgIcon: string,
        public imgPreview: string,
        public datePost: Date,
        public dateStart: Date,
        public dateEnd: Date,
        public count: number
    ){}
}

export class AdditionalEducationPreview {
    constructor(
        public id: number,
        public headline: string,
        public announce: string,
        public imgIcon: string,
        public datePost: Date,
        public dateStart: Date,
        public dateEnd: Date,
        public count: number
    ){}
}