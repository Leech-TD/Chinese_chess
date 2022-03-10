<?php


namespace app\admin\controller;


class Talk extends Base
{
    public function index()
    {
        if (request()->isAjax()) {
            $get = $this->request->get();
            $limit = $get['limit'] ?? 10;
            $list = db('message')

                ->join('goods','message.gid=goods.goods_id','left')
                ->where('goods.user_id', session('user_id'))
               // ->join('sys_user','message.uid=goods.goods_id','left')

                ->paginate($limit)
                ->toArray();
            return $this->showList($list);
        } else {
            return view();
        }
    }


    public function talkDel()
    {
        $id=input('post.id');
        db('message')->delete($id);
        return $this->success('删除成功！');
    }

    public function type()
    {
        return view();
    }
    public function typeData()
    {
        $list = db('book_type')->select();
        return $this->showAll($list);
    }

}