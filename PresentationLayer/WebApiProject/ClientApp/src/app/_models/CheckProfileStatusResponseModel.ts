export interface CheckProfileStatusResponseModel {
    bucketInfo: BucketInfoModel[];
    errorDoc: ErrorDocModel;
}

export interface BucketInfoModel {
    currentBucketId: string;
    currentBucketName: string;
    isRnR: string;
    rnRText: string;
    optionsList: OptionsListModel[];
}

export interface ErrorDocModel{
    status: string;
    errorCode: string;
    errorMessage: string;
}

export interface OptionsListModel {
    optionId: string;
    optionName: string;
}